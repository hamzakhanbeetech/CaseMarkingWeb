using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; // Add this import for Entity Framework
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Application.Service;
using DataAccessLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services; // Define the services variable

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAuthorization();

// Add configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


builder.Services.AddAuthentication(options =>
{ options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(options => {
                    options.SaveToken = true; options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                    };
                });
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICaseCategoryService, CaseCategoryService>();
builder.Services.AddTransient<ICourtsService, CourtsService>();
builder.Services.AddTransient<Case_Marking_Web_Application.Interfaces.IAuthenticationService, Case_Marking_Web_Application.Service.AuthenticationService>();

// Add DbContext
services.AddDbContext<CaseMarkingDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // Use the configuration object to get the connection string

// Configure Identity Framework
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CaseMarkingDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Add authentication and authorization middleware here
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());



app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();
app.Run();

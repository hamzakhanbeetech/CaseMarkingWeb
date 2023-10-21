using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Applications.Models;
using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly CaseMarkingDbContext _dbContext;

    public AuthController(CaseMarkingDbContext dbContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserService userService)
    {
        _userService = userService;        
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _dbContext = dbContext;
    }

    [HttpGet]
    [Route("IsUserEmailExist/{email}")]
    public async Task<IActionResult> IsUserEmailExist(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            return Ok("User Exist");
        }
        else
        {
            return BadRequest("User Not Exist");
        }
    }

    [HttpGet]
    [Route("IsUserExit/{username}")]
    public async Task<IActionResult> IsUserExit(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            return BadRequest("User Not Exist");
        }
        return Ok("User Exist");
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Regiser(RegisterViewModel signUp)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new IdentityUser
        {
            UserName = signUp.Email,
            Email = signUp.Email
            

        };

        var result = await _userManager.CreateAsync(user, signUp.Password);

        if (result.Succeeded)
        {
            var userFromDb = await _userManager.FindByNameAsync(user.UserName);
            var userEmail = user.Email.Split('@')[1];
            var checkAdmin = false;
            if (userEmail == "Grocery.com")
                checkAdmin = true;
            if (checkAdmin)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _userManager.AddToRoleAsync(user, "User");


            }
            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(result);

        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }


    [HttpPost]
    [Route("add-marked-case")]
    public async Task<IActionResult> AddMarkedCase(AddCaseMarkingRequest model)
    {
        model.CaseNo = HttpContext.Connection.RemoteIpAddress.ToString();
        return await _userService.AddMarkedCase(model);
    }

    [HttpGet]
    [Route("get-marked-case-history")]
    public async Task<IActionResult> GetMarkingHistory(DateTime? dateFrom, DateTime? dateTo)
    {
        return await _userService.GetMarkingHistory(dateFrom, dateTo);
    }


}

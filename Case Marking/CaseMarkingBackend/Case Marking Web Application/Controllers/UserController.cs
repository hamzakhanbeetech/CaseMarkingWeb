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


    [HttpPost]
    [Route("add-marked-case")]
    public async Task<IActionResult> AddMarkedCase(AddCaseMarkingRequest model)
    {
        model.CreatedBy = HttpContext.Connection.RemoteIpAddress.ToString();

        // Get the port number of the client from the HttpContext
        int? port = HttpContext.Connection.RemotePort;

        return await _userService.AddMarkedCase(model);
    }

    [HttpGet]
    [Route("get-marked-case-history/{userId}")]
    public async Task<IActionResult> GetMarkingHistory(int userId, DateTime? dateFrom, DateTime? dateTo)
    {
        return await _userService.GetMarkingHistory(userId, dateFrom, dateTo);
    }


}

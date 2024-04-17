using Azure.Core;
using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Applications.Models;
using Case_Marking_Web_Applications.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TowerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeManagementService _employeeManagementService;

        public EmployeeManagementController(IEmployeeManagementService employeeManagementService) 
        {
            _employeeManagementService = employeeManagementService;
        }


        [HttpPost]
        [Route("add-employee")]
        public async Task<IActionResult> AddEmployee(Employee model)
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            // Get the port number of the client from the HttpContext
            int? port = HttpContext.Connection.RemotePort;

            return await _employeeManagementService.AddEmployee(model);


        }


        [HttpGet]
        [Route("employee-list")]
        public async Task<IActionResult> GetEmployeeList()
        {

            return await _employeeManagementService.GetEmployeeList();

        }


        [HttpGet]
        [Route("employee-detail/{id}")]
        public async Task<IActionResult> GetEmployeeDetail(int id)
        {

            return await _employeeManagementService.GetEmployeeDetail(id);

        }


        [HttpPost]
        [Route("transfer-employee/{id}")]
        public async Task<IActionResult> TransferEmployee(AddEmployementHistoryDTO request)
        {

            return await _employeeManagementService.TransferEmployee(request);

        }


        [HttpGet]
        [Route("get-transfer-history/{id}")]
        public async Task<IActionResult> EmployeeTransferHistory(int id)
        {

            return await _employeeManagementService.EmployeeTransferHistory(id);

        }
    }
}

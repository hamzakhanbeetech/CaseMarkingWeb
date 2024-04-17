using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Case_Marking_Web_Application.Interfaces;
using DataAccessLayer.Models;
using Case_Marking_Web_Applications.Models;
using HydroPathSystemAPI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Case_Marking_Web_Applications.Models.DTOs;

namespace Case_Marking_Web_Application.Service
{
    public class EmployeeManagementService: ControllerBase, IEmployeeManagementService
    {
        private readonly CaseMarkingDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeManagementService(CaseMarkingDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> AddEmployee(Employee model)
        {

            var fileName = await FileHandler.SaveFileToStorage(model.ProfileImage, "image");


            if (fileName == null)
            {
                throw new Exception("Error while saving files");
            }
            // Save the image path to the database
            var filePath = "attachements/" + fileName;

            model.ProfileImage = filePath;
            _dbContext.Employee.Add(model);

            _dbContext.SaveChanges();

            return Ok();

        }
        public async Task<IActionResult> GetEmployeeList()
        {
            var empList = _dbContext.Employee.ToList();

            return Ok(empList);
        }

        public async Task<IActionResult> GetEmployeeDetail(int id)
        {
            var result = _dbContext.Employee.Select(e => new
            {
                e.EmployeeID,
                e.Firstname,
                e.Lastname,
                e.Fathername,
                e.PhoneNumber,
                e.Desgination,
                e.PayScale,
                e.CNIC,
                e.DateOfJoining,
                e.CreatedAt,
                profileImage = FileHandler.GetImageAsBase64FromPath(e.ProfileImage, _hostingEnvironment)
            }).FirstOrDefault(e => e.EmployeeID == id);

            return Ok(result);
        }

        public async Task<IActionResult> TransferEmployee(AddEmployementHistoryDTO request)
        {
            if (request == null) return BadRequest();

            var empHistoryObj = new EmploymentHistory
            {
                EmployeeID = request.EmployeeID,
                PreviousPosition = request.PreviousPosition,
                NewPosition = request.NewPosition,
                WorkAs = request.WorkAs,
                TransferDate = request.TransferDate,
                PayScale = request.PayScale,
                OfficeName = request.OfficeName

            };

            _dbContext.EmploymentHistory.Add(empHistoryObj);
            _dbContext.SaveChanges();

            return Ok();
        }

        public async Task<IActionResult> EmployeeTransferHistory(int id)
        {
            var result = _dbContext.EmploymentHistory.Where(empH => empH.EmployeeID == id).OrderByDescending(e => e.EmploymentHistoryID);

            return Ok(result);
        }

    }
}

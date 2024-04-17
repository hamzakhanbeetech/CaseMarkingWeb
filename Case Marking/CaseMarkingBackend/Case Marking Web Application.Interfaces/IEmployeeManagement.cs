using Case_Marking_Web_Applications.Models;
using Case_Marking_Web_Applications.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface IEmployeeManagementService
    {
        public Task<IActionResult> AddEmployee(Employee model);
        public Task<IActionResult> GetEmployeeList();
        public Task<IActionResult> GetEmployeeDetail(int id);
        public Task<IActionResult> TransferEmployee(AddEmployementHistoryDTO request);
        public Task<IActionResult> EmployeeTransferHistory(int id);
    }
}

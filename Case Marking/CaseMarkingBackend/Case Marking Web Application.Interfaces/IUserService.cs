using Case_Marking_Web_Applications.Models;
using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface IUserService
    {
        public Task<IActionResult> AddMarkedCase(AddCaseMarkingRequest model);
        public Task<IActionResult> GetMarkingHistory(int userId, DateTime? dateFrom, DateTime? dateTo);
    }
}

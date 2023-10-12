using Case_Marking_Web_Applications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface IUserService
    {
        public Task<IActionResult> AddMarkedCase(MarkedCases model);
        public Task<IActionResult> GetMarkingHistory(DateTime? dateFrom, DateTime? dateTo);
    }
}

using Case_Marking_Web_Application.DataAccessLayer;
using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Applications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Marking_Web_Application.Service
{
    public class UserService: ControllerBase, IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> AddMarkedCase(MarkedCases model)
        {
            _dbContext.MarkedCases.Add(model);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Car rented successfully." });
        }

        public async Task<IActionResult> GetMarkingHistory(DateTime? dateFrom, DateTime? dateTo)
        {
            var markingHistory = _dbContext.MarkedCases.Where(c => c.MarkedDate >= dateFrom && c.MarkedDate <= dateTo).ToList();


            var result = _dbContext.MarkedCases
            .Where(c => c.MarkedDate >= dateFrom && c.MarkedDate <= dateTo)
            .GroupBy(c => new { c.CaseCategory })
            .Select(g => new
            {
                CaseCategory = g.Key.CaseCategory,
                Stats = g.GroupBy(c => c.CourtName)
                         .Select(innerGroup => new
                         {
                             CourtName = innerGroup.Key,
                             NumberOfCases = innerGroup.Count()
                         })
            })
            .ToList();



            return Ok(result);
        }
    }
}

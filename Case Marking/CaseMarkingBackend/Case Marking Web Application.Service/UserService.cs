using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Applications.Models;
using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Marking_Web_Application.Service
{
    public class UserService: ControllerBase, IUserService
    {
        private readonly CaseMarkingDbContext _dbContext;

        public UserService(CaseMarkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> AddMarkedCase(AddCaseMarkingRequest model)
        {
            var caseMarkingObj = new CaseMarking
            {
                CaseCategoryId = model.CaseCategoryId,
                CourtId = model.CourtId,
                CaseNo = model.CaseNo,
                CaseTitle = model.CaseTitle,
                MarkingDate = model.MarkedDate,
                CreatedBy = model.CreatedBy,
                UserId = model.AddedByUserId ?? null
            
            };

            _dbContext.CaseMarkings.Add(caseMarkingObj);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Car rented successfully." });
        }

        public async Task<IActionResult> GetMarkingHistory(int userId, DateTime? dateFrom, DateTime? dateTo)
        {

            var result = (from cc in _dbContext.CaseCategories
                          where cc.UserId == userId
                          from c in _dbContext.Courts
                          where c.UserId ==  userId
                          select new
                          {
                              caseCategory = cc.CategoryName,
                              caseCategoryId = cc.CaseCategoryId,
                              courtName = c.CourtName,
                              courtId = c.CourtId,
                              totalCasesMarked = (from cm in _dbContext.CaseMarkings
                                                  where cm.CaseCategoryId == cc.CaseCategoryId && cm.CourtId == c.CourtId
                                                  && cm.MarkingDate >= dateFrom && cm.MarkingDate <= dateTo
                                                  select cm).Count()
                          }).ToList();

            var groupedResult = result
                .GroupBy(r => r.caseCategory)
                .Select(g => new
                {
                    caseCategory = g.Key,
                    caseCategoryId = g.Select(cc => cc.caseCategoryId).FirstOrDefault(),
                    stats = g.Select(r => new
                    {
                        courtName = r.courtName,
                        courtID = r.courtId,
                        totalCasesMarked = r.totalCasesMarked
                    }).ToList()
                }).ToList();



            return Ok(groupedResult);
        }
    }
}

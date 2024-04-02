using Case_Marking_Web_Application.Interfaces;
using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Service
{
    public class CourtsService: ICourtsService
    {
        private readonly CaseMarkingDbContext _dbContext;

        public CourtsService(CaseMarkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Court> GetCourts(int userId)
        {
            var caseCategoryList = _dbContext.Courts.Where(c => c.UserId == userId).ToList();
            return caseCategoryList;
        }

        public Court AddCourt(AddCourtRequest court)
        {
            var courtObj = new Court
            {
                CourtName = court.CourtName,
                Status = court.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = court.UserId
            };

            _dbContext.Courts.Add(courtObj);
            _dbContext.SaveChanges();
            return courtObj;
        }
        public Court? DeleteCourt(int id)
        {
            var caseCat = _dbContext.Courts.Where(c => c.CourtId == id).FirstOrDefault();

            if (caseCat != null)
            {
                _dbContext.Courts.Remove(caseCat);
                _dbContext.SaveChanges();

                return caseCat;
            }
            return caseCat;
        }
    }
}

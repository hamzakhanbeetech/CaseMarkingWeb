using Case_Marking_Web_Application.Interfaces;
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
        public List<Court> GetCourts()
        {
            var caseCategoryList = _dbContext.Courts.ToList();
            return caseCategoryList;
        }

        public Court AddCourt(Court caseCategory)
        {
            _dbContext.Courts.Add(caseCategory);
            _dbContext.SaveChanges();
            return caseCategory;
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

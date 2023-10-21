using Case_Marking_Web_Application.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Service
{
    public class CaseCategoryService: ICaseCategoryService
    {
        private readonly CaseMarkingDbContext _dbContext;

        public CaseCategoryService(CaseMarkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CaseCategory> GetCaseCategories()
        {
            var caseCategoryList = _dbContext.CaseCategories.ToList();
            return caseCategoryList;
        }

        public CaseCategory AddCaseCategory(CaseCategory caseCategory)
        {
            _dbContext.CaseCategories.Add(caseCategory);
            _dbContext.SaveChanges();
            return caseCategory;
        }
        public CaseCategory? DeleteCaseCategory(int id)
        {
            var caseCat = _dbContext.CaseCategories.Where(c => c.CaseCategoryId == id).FirstOrDefault();

            if (caseCat != null)
            {
                _dbContext.CaseCategories.Remove(caseCat);
                _dbContext.SaveChanges();

                return caseCat;
            }
            return caseCat;
        }
    }
}

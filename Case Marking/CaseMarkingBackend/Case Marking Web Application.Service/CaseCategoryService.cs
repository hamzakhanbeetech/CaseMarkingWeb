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
    public class CaseCategoryService: ICaseCategoryService
    {
        private readonly CaseMarkingDbContext _dbContext;

        public CaseCategoryService(CaseMarkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CaseCategory> GetCaseCategories(int userId)
        {
            var caseCategoryList = _dbContext.CaseCategories.Where(cc => cc.UserId == userId).ToList();
            return caseCategoryList;
        }

        public CaseCategory AddCaseCategory(AddCaseCategoryRequest caseCategory)
        {
            var caseCategoryObj = new CaseCategory
            {
                CategoryName = caseCategory.CategoryName,
                CreatedAt = DateTime.Now,
                UserId = caseCategory.UserId,
            };

            _dbContext.CaseCategories.Add(caseCategoryObj);
            _dbContext.SaveChanges();
            return caseCategoryObj;
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

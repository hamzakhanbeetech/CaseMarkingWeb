using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface ICaseCategoryService
    {
        public List<CaseCategory> GetCaseCategories(int userId);
        public CaseCategory AddCaseCategory(AddCaseCategoryRequest caseCategory);
        public CaseCategory? DeleteCaseCategory(int id);
    }
}

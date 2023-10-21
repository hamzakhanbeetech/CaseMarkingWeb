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
        public List<CaseCategory> GetCaseCategories();
        public CaseCategory AddCaseCategory(CaseCategory caseCategory);
        public CaseCategory? DeleteCaseCategory(int id);
    }
}

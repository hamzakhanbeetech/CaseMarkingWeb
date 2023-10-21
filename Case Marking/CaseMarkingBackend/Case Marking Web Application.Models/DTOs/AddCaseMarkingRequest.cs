using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Applications.Models.DTOs
{

    public class AddCaseMarkingRequest
    {
        public int CaseCategoryId { get; set; }
        public string CaseNo { get; set; }
        public string CaseTitle { get; set; }
        public int CourtId { get; set; }
        public DateTime MarkedDate { get; set; }
        public string CreatedBy { get; set;}
    }
    
}

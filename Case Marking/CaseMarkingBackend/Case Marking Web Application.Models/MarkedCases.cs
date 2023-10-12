using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Applications.Models
{
    public class MarkedCases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MarkedCaseID { get; set; }
        public string CaseNo { get; set; }
        public string CaseTitle { get; set; }
        public DateTime? MarkedDate { get; set; }
        public string CourtName { get; set; }
        public string CaseCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Applications.Models.DTOs
{
    public class AddEmployementHistoryDTO
    {
        [Key]
        public int EmploymentHistoryID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [StringLength(250)]
        public string PreviousPosition { get; set; }

        [StringLength(250)]
        public string NewPosition { get; set; }

        [StringLength(250)]
        public string OfficeName { get; set; }

        public DateTime? TransferDate { get; set; }

        [StringLength(250)]
        public string WorkAs { get; set; }

        [StringLength(250)]
        public string PayScale { get; set; }

        public bool? IsActive { get; set; }
    }
}

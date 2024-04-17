using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Applications.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(250)]
        public string Firstname { get; set; }

        [StringLength(250)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(250)]
        public string Fathername { get; set; }

        [Required]
        [StringLength(250)]
        public string CNIC { get; set; }

        [Required]
        [StringLength(250)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string Desgination { get; set; }
        

        [Required]
        public string ProfileImage { get; set; }

        [Required]
        [StringLength(50)]
        public string PayScale { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = new List<EmploymentHistory>();
    }
}

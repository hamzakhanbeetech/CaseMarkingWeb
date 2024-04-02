using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Applications.Models.DTOs
{
    public class AddCaseCategoryRequest
    {
        public int CaseCategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public int? UserId { get; set; }
    }
}

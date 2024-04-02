using Case_Marking_Web_Applications.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CaseCategory
{
    public int CaseCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public int? UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<CaseMarking> CaseMarkings { get; set; } = new List<CaseMarking>();
}

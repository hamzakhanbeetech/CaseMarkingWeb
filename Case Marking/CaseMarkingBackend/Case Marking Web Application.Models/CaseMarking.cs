using Case_Marking_Web_Applications.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CaseMarking
{
    public int CaseMarkingId { get; set; }

    public string CaseTitle { get; set; } = null!;

    public int CourtId { get; set; }

    public int CaseCategoryId { get; set; }

    public DateTime MarkingDate { get; set; }

    public string? CaseNo { get; set; }

    public string? CreatedBy { get; set; }

    public int? UserId { get; set; }

    public virtual CaseCategory CaseCategory { get; set; } = null!;

    public virtual Court Court { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

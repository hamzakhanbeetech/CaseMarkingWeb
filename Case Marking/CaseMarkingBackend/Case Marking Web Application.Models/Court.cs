using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Court
{
    public int CourtId { get; set; }

    public string CourtName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<CaseMarking> CaseMarkings { get; set; } = new List<CaseMarking>();
}

using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class MarkedCase
{
    public long MarkedCaseId { get; set; }

    public string CaseNo { get; set; } = null!;

    public string CaseTitle { get; set; } = null!;

    public DateTime? MarkedDate { get; set; }

    public string CourtName { get; set; } = null!;

    public string CaseCategory { get; set; } = null!;
}

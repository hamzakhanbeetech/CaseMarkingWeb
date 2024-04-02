using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace Case_Marking_Web_Applications.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    public virtual ICollection<CaseCategory> CaseCategories { get; set; } = new List<CaseCategory>();

    public virtual ICollection<CaseMarking> CaseMarkings { get; set; } = new List<CaseMarking>();
}

using Case_Marking_Web_Applications.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CaseMarkingDbContext 
{

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<CaseCategory> CaseCategories { get; set; }

    public virtual DbSet<CaseMarking> CaseMarkings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<MarkedCase> MarkedCases { get; set; }

    public virtual DbSet<User> Users { get; set; }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

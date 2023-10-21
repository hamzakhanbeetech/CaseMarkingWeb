using Case_Marking_Web_Applications.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class CaseMarkingDbContext : DbContext
{
    public CaseMarkingDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<CaseCategory> CaseCategories { get; set; }

    public virtual DbSet<CaseMarking> CaseMarkings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


    }
}

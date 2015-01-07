using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}
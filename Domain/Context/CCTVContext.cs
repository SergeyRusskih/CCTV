using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Domain.Context
{
    public class CCTVContext : DbContext
    {
        public DbSet<IpCam> IpCams { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
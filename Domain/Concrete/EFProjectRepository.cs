using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Concrete
{
    public class EFProjectRepository : IProjects
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Project> Projects
        {
            get { return context.Projects; }
        }
    }
}
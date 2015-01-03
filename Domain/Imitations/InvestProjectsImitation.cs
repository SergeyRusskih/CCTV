using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Imitations
{
    public class InvestProjectsImitation : IInvestProjects
    {
        public IQueryable<InvestProject> InvestProjects
        {
            get
            {
                return (new List<InvestProject> {
                    new InvestProject { Id = 1, Title = "Project1", Name = "Project1", CamId = 1 }

                }).AsQueryable();
            }

        }
    }
}
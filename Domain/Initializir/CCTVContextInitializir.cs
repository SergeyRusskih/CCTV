using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Domain.Initializir
{
    public class CCTVContextInitializir : DropCreateDatabaseAlways<CCTVContext>
    {
        protected override void Seed(CCTVContext context)
        {
            var ipCams = new List<IpCam>
            {
                new IpCam { 
                    Name = "First cam", 
                    Address = "128.197.178.101", 
                    Param = "",  
                    TypeCam = "axis",
                },
                new IpCam {
                    Name = "Second cam",
                    Address = "148.61.63.218",
                    Param = "",
                    TypeCam = "axis"
                },
                //new IpCam { Name = "Second cam", Address = "193.138.213.160/CgiStart?page=Single&Mode=Motion&Language=9" }
            };

            context.Projects.Add(
                new Project()
                {
                    Name = "First project",
                    Descr = "My first project",
                    IpCams = ipCams

            });

            context.SaveChanges();
        }
    }
}
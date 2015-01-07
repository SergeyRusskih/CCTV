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
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
                new IpCam { Name = "af", Adress = "adf" },
            };

            context.Projects.Add(
                new Project()
                {
                    ProjectID = 1,
                    Name = "First project",
                    Descr = "My first project",
                    IpCams = ipCams

                });
            //context.IpCams.Add(
            //    new IpCam() { Name = "First IpCam",
            //                  Adress = "http://148.61.63.218/view/viewer_index.shtml?id=402",
            //                  Project = context.Projects.Add(
            //                     new Project() {
            //                         Name = "First project",
            //                         Descr = "It's my fitrst project"
            //                     })
            //});
            //context.IpCams.Add(
            //    new IpCam()
            //    {
            //        Name = "Second IpCam",
            //        Adress = "http://148.61.63.218/view/viewer_index.shtml?id=402",
            //        Project = context.Projects.Add(
            //           new Project()
            //           {
            //               Name = "First project",
            //               Descr = "It's my fitrst project"
            //           })
            //    });

            context.SaveChanges();
        }
    }
}
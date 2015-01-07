using AForge.Video;
using AForge.Video.DirectShow;
using Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CCTV.Controllers
{
    public class InvestController : BaseController
    {
        [Inject]
        public IProjects projectList { get; set; }

        // GET: Invest
        public ActionResult Index()
        {
            return View(projectList.Projects);
        }

    }
}
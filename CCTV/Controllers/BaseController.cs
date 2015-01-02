using Domain.Abstract;
using Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCTV.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IMainMenu mainMenu { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.MainMenu = mainMenu.Menu;
            base.OnActionExecuting(filterContext);
        }
    }
}

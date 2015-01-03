using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CCTV.HtmlHelpers
{
        public static class MainHelpers
        {
            public static MvcHtmlString MainMenu(this HtmlHelper html, IQueryable<MenuItem> mainMenu)
            {
                StringBuilder result = new StringBuilder();
                    //                <li><a class="navbar-brand" href="#">Главная</a></li>
                    //<li class="active"><a href="#">Link</a></li>
                    //<li><a href="#">Link</a></li>
                var menu = mainMenu.ToArray();
                for (var i = 0; i < menu.Length; i++)
                {

                    TagBuilder a = new TagBuilder("a");
                    a.Attributes.Add("href", menu[i].Link);
                    a.InnerHtml = menu[i].Name;
                    //tag.InnerHtml = mainMenu[i].Name.ToSting();
                    TagBuilder li = new TagBuilder("li");
                    li.InnerHtml = a.ToString();
                    result.Append(li.ToString());
                }
                return MvcHtmlString.Create(result.ToString());
            }
        }
}
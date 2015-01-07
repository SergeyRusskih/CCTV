using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Imitations
{
    public class MainMenuImitation : IMainMenu
    {
        public IQueryable<MenuItem> Menu
        {
            get {
                return (new List<MenuItem> {
                    new MenuItem { Id = 1, Name = "Главная",Link = "/Home",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 2, Name = "Инвестпроекты",Link = "/Invest",  ParentId = null, CurrentPage = false }
                }).AsQueryable();
            }

        }
    }
}
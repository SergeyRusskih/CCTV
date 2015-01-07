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
                    new MenuItem { Id = 9, Name = "Главная",Link = "/home",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 9, Name = "Инвестпроекты",Link = "/invest",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 9, Name = "Администрирование",Link = "/admin",  ParentId = null, CurrentPage = false },
                }).AsQueryable();
            }

        }
    }
}
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
                    new MenuItem { Id = 1, Name = "Главная", Link = "/", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 2, Name = "Пункт1",  Link = "/",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 3, Name = "Пункт2",  Link = "/",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 4, Name = "Пункт3",  Link = "/",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 5, Name = "Пункт4",  Link = "/", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 6, Name = "Пункт5",  Link = "/", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 7, Name = "Пункт6",  Link = "/", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 8, Name = "Пункт7",  Link = "/", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 9, Name = "Инвестпроекты",Link = "/invest",  ParentId = null, CurrentPage = false },
                }).AsQueryable();
            }

        }
    }
}
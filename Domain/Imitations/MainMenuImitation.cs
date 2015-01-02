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
                    new MenuItem { Id = 1, Name = "Главная", ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 2, Name = "Пункт1",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 3, Name = "Пункт2",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 4, Name = "Пункт3",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 5, Name = "Пункт4",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 6, Name = "Пункт5",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 7, Name = "Пункт6",  ParentId = null, CurrentPage = false },
                    new MenuItem { Id = 8, Name = "Пункт7",  ParentId = null, CurrentPage = false },
                }).AsQueryable();
            }

        }
    }
}
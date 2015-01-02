using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool CurrentPage { get; set; }

    }
}
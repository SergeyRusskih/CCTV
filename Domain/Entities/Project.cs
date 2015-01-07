using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
    }
}
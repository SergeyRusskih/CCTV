using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class InvestProject
    {
        public int Id { get; set; }
        public int CamId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
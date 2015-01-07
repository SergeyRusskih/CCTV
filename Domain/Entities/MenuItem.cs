using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public bool CurrentPage { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Link { get; set; }
    }
}
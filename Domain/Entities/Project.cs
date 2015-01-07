using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class Project
    {
        public Int32 ProjectID { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Название проекта")]
        [DataType(DataType.Text)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Описание проекта")]
        [DataType(DataType.MultilineText)]
        public String Descr { get; set; }

        public virtual List<IpCam> IpCams { get; set; }
    }
}
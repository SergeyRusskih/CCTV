using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class IpCam
    {
        public Int32 IpCamID { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Ip адрес")]
        [DataType(DataType.Text)]
        public String Adress { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения")]
        [Display(Name = "Название")]
        [DataType(DataType.Text)]
        public String Name { get; set; }

        public Int32 ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
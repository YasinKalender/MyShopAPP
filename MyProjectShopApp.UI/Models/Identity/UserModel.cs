using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Identity
{
    public class UserModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare("Password")] //Compare: Eşleştirme yaparak karşılaştırır
        public string RePassword { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string  Mail { get; set; }


    }
}

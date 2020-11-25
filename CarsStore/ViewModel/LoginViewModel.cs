using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name cant be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cant be empty")]
        public string Password { get; set; }


    }
}
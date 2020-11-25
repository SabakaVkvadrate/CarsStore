using CarsStore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.UserViewModel
{
    public class UserDeleteViewModel:BaseDeleteViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string  Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
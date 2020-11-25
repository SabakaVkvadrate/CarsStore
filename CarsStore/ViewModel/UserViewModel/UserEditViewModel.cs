using CarsStore.ViewModel.BaseViewModel;
using System.ComponentModel.DataAnnotations;

namespace CarsStore.ViewModel.UserViewModel
{
    public class UserEditViewModel:BaseEditViewModel
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The Username can contain at least 3 characters")]
        [Required(ErrorMessage = "Login is required")]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = " Please enter correct Password")]
        [Required(ErrorMessage = "Pass is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "The Firstname can contain at least 4 characters")]
        [Required(ErrorMessage = "FName is required")]
        public string Firstname { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "The Lastname can contain at least 4 characters")]
        [Required(ErrorMessage = "LName is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Mail is required")]
        [EmailAddress(ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }


        public bool IsAdmin { get; set; }
    }
}
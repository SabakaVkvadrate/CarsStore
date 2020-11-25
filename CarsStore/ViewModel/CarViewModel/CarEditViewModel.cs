using CarsStore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.CarViewModel
{
    public class CarEditViewModel : BaseEditViewModel
    {
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(30)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(30)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Manafacture Date is required")]
        [DataType(DataType.Date)]
        public DateTime ManafDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Source is required")]
        [DataType(DataType.ImageUrl)]
        public string ImgLink { get; set; }

    }
}
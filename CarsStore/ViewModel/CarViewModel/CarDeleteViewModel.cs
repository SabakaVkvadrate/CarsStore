using CarsStore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.CarViewModel
{
    public class CarDeleteViewModel: BaseDeleteViewModel
    {
        public string Brand { get; set; }     
        public string Model { get; set; }     
        public DateTime ManafDate { get; set; }
        public int Price { get; set; }
        public string ImgLink { get; set; }

    }
}
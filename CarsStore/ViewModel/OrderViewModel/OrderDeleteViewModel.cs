using CarsStore.ViewModel.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.OrderViewModel
{
    public class OrderDeleteViewModel : BaseDeleteViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }

    }
}
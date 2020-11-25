using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.OrderViewModel
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public bool Warranty { get; set; }
  

    }
}
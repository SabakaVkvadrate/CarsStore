using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF.Entities
{
  public  class OrderData : BaseEntity
    {
        // ENtity where  stores onformation about of results from sqlQuery
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

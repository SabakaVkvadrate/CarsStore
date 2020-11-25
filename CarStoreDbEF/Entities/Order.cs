using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF.Entities
{
    public class Order : BaseEntity
    {

        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Warranty { get; set; }

    }
}

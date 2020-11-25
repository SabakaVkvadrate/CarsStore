using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF.Entities
{
    public abstract class BaseEntity // потому что нельзя создавать бейз энтити просто так 
    {
        public int Id { get; set; }
    }
}

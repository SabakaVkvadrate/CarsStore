using CarStoreDbEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name= CarStoreDb") { }

        public DbSet<Car> cars { get; set; }// названия  таблиц
        public DbSet<Order> orders { get; set; }
        public DbSet<User> users { get; set; }

        object placeHolderVariable;
    }
}

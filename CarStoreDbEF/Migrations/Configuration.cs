namespace CarStoreDbEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarStoreDbEF.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;  // solution for Exception 
        }

    }
}

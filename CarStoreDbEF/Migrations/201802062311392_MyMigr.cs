namespace CarStoreDbEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        ManafDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        ImgLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Warranty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO USERS " +
        "VALUES('a', 'a','Paul','kyrnacz','kyrnacz','1')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
        }
    }
}

using CarStoreDbEF.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace CarStoreDbEF.Repository
{
    public class OrderRepository : BaseRepository<Order>
    {
        public List<OrderData> getOrderData(string connectionString)
        {
            IDbConnection connection = new SqlConnection(connectionString);

            List<OrderData> list = new List<OrderData>();

            try
            {
                connection.Open();

                IDbCommand command = connection.CreateCommand();
                command.CommandText =
                      @"Select o.Id ,Brand, Model, FirstName+' '+LastName as Name, u.Id as UserId , c.Id as CarId, OrderDate,Price,Warranty
                        from Orders o join Cars c
                        on o.CarId=c.Id
                        join Users u 
                        on u.Id= o.UserId";

                IDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        OrderData orderData = new OrderData();
                        orderData.Id = (int)reader["Id"];
                        orderData.UserId = (int)reader["UserId"];
                        orderData.CarId = (int)reader["CarId"];
                        orderData.Name = (string)reader["Name"];
                        orderData.Brand = (string)reader["Brand"];
                        orderData.Model = (string)reader["Model"];
                        orderData.OrderDate = (DateTime)reader["OrderDate"];
                        orderData.Price = (int)reader["Price"];
                        orderData.Warranty = (bool)reader["Warranty"];

                        list.Add(orderData);
                    }

                }
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}

using CarStoreDbEF.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreDbEF.Repository
{
    public class CarRepository : BaseRepository<Car>
    {
        public List<Car> GetTopCars(string connectionString)
        {
            IDbConnection connection = new SqlConnection(connectionString);

            List<Car> list = new List<Car>();

            try
            {
                connection.Open();

                IDbCommand command = connection.CreateCommand();
                command.CommandText =
                      @"Select Top 10 Id,Brand, Model, Price From Cars order by Price desc";

                IDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Car topCars = new Car();
                        topCars.Id = (int)reader["Id"];
                        topCars.Brand = (string)reader["Brand"];
                        topCars.Model = (string)reader["Model"];
                        topCars.Price = (int)reader["Price"];

                        list.Add(topCars);
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

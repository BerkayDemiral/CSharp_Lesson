using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListWithDatabase
{
    public class ProductsDal
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb; initial catalog=Products; integrated security=true");
        public List<Products> Print()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Select *from Products", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Products> products = new List<Products>();
            while (reader.Read())
            {
                Products product = new Products()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    Stock = Convert.ToInt32(reader["Stock"]),
                    Price = Convert.ToInt32(reader["Price"])
                };
                products.Add(product);
            }

            reader.Close();
            connection.Close();
            return products;
        }
        public void add(Products product)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Insert into Products values(@Name,@Stock,@Price)", connection);
            command.Parameters.AddWithValue("Name", product.Name);
            command.Parameters.AddWithValue("Stock", product.Stock);
            command.Parameters.AddWithValue("Price", product.Price);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void update(Products product)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Update Products set Name=@Name, Stock=@Stock, Price=@Price where Id=@Id", connection);
            command.Parameters.AddWithValue("Name", product.Name);
            command.Parameters.AddWithValue("Stock", product.Stock);
            command.Parameters.AddWithValue("Price", product.Price);
            command.Parameters.AddWithValue("Id", product.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void delete(Products product)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Delete from Products where Id=@Id", connection);
            command.Parameters.AddWithValue("Id", product.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

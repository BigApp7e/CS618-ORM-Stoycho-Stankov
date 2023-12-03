using CS618_ORM_Stoycho_Stankov.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CS618_ORM_Stoycho_Stankov.Controllers
{
    internal class ShopController
    {
        SqlConnection con;
        public ShopController() {
            con  = new SqlConnection(AppModel.connectionString);
        }

        public List<Products> getAllProducts()
        {
            Console.WriteLine("Get All Products!");

            tryToOpenConnect();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Products> productList = new List<Products>();

            if (dr.Read())
            {
                Products product = new Products();
                product.Name = dr["Name"].ToString();
                product.Description = dr["Description"].ToString();
                product.Price = Convert.ToInt32(dr["Price"]);
                product.Created = DateTime.Parse(dr["Created"].ToString());
                product.Updated = DateTime.Parse(dr["Updated"].ToString());
                product.SalesId = Convert.ToInt32(dr["SalesId"]);
                product.sales = getSelesById(product.SalesId);
                productList.Add(product);
            }

            con.Close();

            return productList;
        }
        public Sales getSelesById(int id)
        {
            Console.WriteLine("Get sales by Id!");

            tryToOpenConnect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM sales Where id="+id.ToString(), con);
            SqlDataReader dr = cmd.ExecuteReader();

            Sales sales = new Sales();

            if (dr.Read())
            {
                sales.Id = Convert.ToInt32(dr["Id"]);
                sales.ProductId = Convert.ToInt32(dr["ProductId"]);
                sales.Quantity = Convert.ToInt32(dr["Quantity"]);
                sales.Name = dr["Name"].ToString();
                sales.Email = dr["Email"].ToString();
                sales.ProductId = Convert.ToInt32(dr["Phone"]);
                sales.Ordered = DateTime.Parse(dr["Ordered"].ToString());
                sales.LastUpdated = DateTime.Parse(dr["LastUpdated"].ToString());
            }

            return sales;

        }
        public void deleteSalesById(int id)
        {
            Console.WriteLine("Delete sales by Id!");

            tryToOpenConnect();

            using (SqlCommand cmd = new SqlCommand("DELETE FROM sales WHERE ID=" + id, con))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Sales Deleted!");
            } 
        }

        public void updateSales(Sales sale)
        {
            Console.WriteLine("Update sale!");

            using (SqlCommand cmd = new SqlCommand("UPDATE sales set ProductId=" + sale.ProductId+ ", Quantity=" + sale.Quantity + ",Name=" + sale.Name + ",Email=" + sale.Email + ",Phone=" + sale.Phone + ",Ordered=" + sale.Ordered + ",LastUpdated="+ sale.LastUpdated + " WHERE Id=" + sale.Id, con))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Sales Updated!");
            }
        }

        public void insertIntoSales(int productId, int quantity, string name, string email, int phone, DateTime ordered, DateTime lastUpdated)
        {
            Console.WriteLine("Insert sale!");

            tryToOpenConnect();
            string query = "INSERT INTO sales (ProductId, Quantity, Name, Email, Phone, Ordered, LastUpdated) VALUES (@ProductId, @Quantity, @Name, @Email, @Phone, @Ordered, @LastUpdated)";


            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = email;
                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = phone;
                cmd.Parameters.AddWithValue("@Ordered", ordered);
                cmd.Parameters.AddWithValue("@LastUpdated", lastUpdated);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

        }

        private void tryToOpenConnect()
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    Console.WriteLine("Connecting ...!");
                    con.Open();
                    Console.WriteLine("Connected!");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    throw;
                }
            }   
        }
    }
}

using CS618_ORM_Stoycho_Stankov.Controllers;
using CS618_ORM_Stoycho_Stankov.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CS618_ORM_Stoycho_Stankov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopController controller = new ShopController();


           controller.insertIntoSales(5, 5, "Mise", "mail@mail.com", 123456789, DateTime.Now, DateTime.Now);

           List<Products> allProducts =  controller.getAllProducts();

           Console.Read();
        }
    }
}

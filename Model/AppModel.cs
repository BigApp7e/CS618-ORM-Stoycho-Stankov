using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS618_ORM_Stoycho_Stankov.Model
{
    internal class AppModel
    {
       public readonly static string database = "Shop";
       public readonly static string connectionString = "Server=localhost;Database="+ database + ";Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS618_ORM_Stoycho_Stankov.Model
{
    internal class Products 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public int SalesId { get; set; }
        public Sales sales { get; set; }


    }
}

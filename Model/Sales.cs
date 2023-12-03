using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS618_ORM_Stoycho_Stankov.Model
{
    internal class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime Ordered {  get; set; }
        public DateTime LastUpdated { get; set; }

        public List<Products> productList {  get; set; }

    }
}

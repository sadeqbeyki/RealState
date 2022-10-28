using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Domain.Entities.Product
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public int price { get; set; }
        public string shortDiscription { get; set; }
    }
}

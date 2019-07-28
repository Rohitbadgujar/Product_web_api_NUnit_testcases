using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_assignment.Model;

namespace WebApi_assignment
{
    public class ProductPage
    {
        public int Total_Product;

        public List<Product> Product_Items { get; set; }
    }
}

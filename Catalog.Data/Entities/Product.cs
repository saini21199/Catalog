using Catalog.Data.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Data.Entities
{
    public class Product: SharedAttributes
    {
        public string Manufacturer { get; set; }
        public List<Category> Categories;
        public int SellingPrice { get; set; }
        public static int proId;
        public Product()
        {
            proId = proId + 1;
            this.Id = proId;
        }
    }
}

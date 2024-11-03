using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using Web_bestcoder.Areas.Admin.Models;
using Web_bestcoder.Data;

namespace Web_bestcoder.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {

        public Product Product { get; set; }
        public List<Data.Product> Products { get; set; }
        public List<Data.ProductCategory> ProductCategories { get; set; } // Ensure this is the same type used in your DbContext
        public List<Data.Supplier> Suppliers { get; set; }

        // Constructor to initialize the lists
        public ProductViewModel()
        {
            ProductCategories = new List<Data.ProductCategory>();
            Suppliers = new List<Data.Supplier>();
            Products = new List<Product>();
            Product = new Product();
        }

      
    }
}

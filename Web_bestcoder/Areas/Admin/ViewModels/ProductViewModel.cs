using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using Web_bestcoder.Areas.Admin.Models;
using Web_bestcoder.Data;

namespace Web_bestcoder.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {

        // Remove the Product property
        public string ProductName { get; set; } // Only include ProductName

        public List<Data.Product> Products { get; set; }
        public List<Data.ProductCategory> ProductCategories { get; set; }
        public List<Data.Supplier> Suppliers { get; set; }
        public Product Product { get; internal set; }
        public int CategoryId { get; internal set; }
        public int SupplierId { get; internal set; }

        // Constructor to initialize the lists
        public ProductViewModel()
        {
            ProductCategories = new List<Data.ProductCategory>();
            Suppliers = new List<Data.Supplier>();
            Products = new List<Product>();
        }


    }
}

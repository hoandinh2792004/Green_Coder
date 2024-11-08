
namespace Web_bestcoder.Areas.Admin.Models
{
    public class Products
    {
        public int Id { get; set; } // Unique identifier for the product

        public string ProductName { get; set; } = string.Empty; // Name of the product

        public string? Image { get; set; } // Optional image URL or path for the product

        public int Quantity { get; set; } // Quantity of the product available

        public string Status { get; set; } = "Available"; // Status of the product (e.g., Available, Out of Stock)

        public decimal SellingPrice { get; set; } // Selling price of the product

        public decimal CostPrice { get; set; } // Cost price of the product

        public int Category { get; set; } // Foreign key to the product category

        public int Supplier { get; set; } // Foreign key to the supplier
        public string Description { get; set; }
        public string ImagePath { get; internal set; }

        public Products()
        {

        }
    }
}

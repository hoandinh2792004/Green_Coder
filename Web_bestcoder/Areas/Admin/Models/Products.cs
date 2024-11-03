using Web_bestcoder.Data;

namespace Web_bestcoder.Areas.Admin.Models
{
    public class Products
    {
        public int ProductId { get; set; } // Unique identifier for the product

        public string ProductName { get; set; } = string.Empty; // Name of the product

        public string? Image { get; set; } // Optional image URL or path for the product

        public int Quantity { get; set; } // Quantity of the product available

        public string Status { get; set; } = "Available"; // Status of the product (e.g., Available, Out of Stock)

        public decimal SellingPrice { get; set; } // Selling price of the product

        public decimal CostPrice { get; set; } // Cost price of the product

        public int CategoryId { get; set; } // Foreign key to the product category

        public int SupplierId { get; set; } // Foreign key to the supplier
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; } // Date when the product was created

        public bool? IsActive { get; set; } // Whether the product is active or not

        // Navigation properties to link with other models
        public ProductCategory? Category { get; set; } // Navigation property for category
        public Supplier? Supplier { get; set; } // Navigation property for supplier

        // Collection of related order details
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

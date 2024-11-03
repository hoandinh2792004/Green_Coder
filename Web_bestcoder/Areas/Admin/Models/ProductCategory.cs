using Web_bestcoder.Data;

namespace Web_bestcoder.Areas.Admin.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; } // Unique identifier for the product category

        public string CategoryName { get; set; } = string.Empty; // Name of the category, cannot be null

        public string? Description { get; set; } // Optional description of the category

        public DateTime? CreatedDate { get; set; } // Date when the category was created

        public bool? IsActive { get; set; } // Indicates if the category is active or not

        // Navigation property to the list of products in this category
        public List<Product> Products { get; set; } = new List<Product>();
    }
}

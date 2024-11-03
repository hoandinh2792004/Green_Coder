using Web_bestcoder.Data;

namespace Web_bestcoder.Areas.Admin.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; } // Unique identifier for the supplier

        public string SupplierName { get; set; } = string.Empty; // Name of the supplier, cannot be null

        public string? ContactName { get; set; } // Optional name of the contact person

        public string? Phone { get; set; } // Optional phone number of the supplier

        public string? Email { get; set; } // Optional email address of the supplier

        public string? Address { get; set; } // Optional physical address of the supplier

        public DateTime? CreatedDate { get; set; } // Date when the supplier record was created

        public bool? IsActive { get; set; } // Indicates if the supplier is active or not

        // Navigation property to the list of products supplied by this supplier
        public List<Product> Products { get; set; } = new List<Product>();
    }
}

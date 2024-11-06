namespace Web_bestcoder.Areas.Admin.Models
{
    public class CreateProduct
    {
        public int ProductId { get; internal set; }
        public string ProductName { get; internal set; }
        public int CategoryId { get; internal set; }
        public int SupplierId { get; internal set; }
        public List<Data.ProductCategory> ProductCategories { get; internal set; }
        public List<Data.Supplier> Suppliers { get; internal set; }

        public class ProductViewModel
        {
            // Ensure these properties match your data model
            public List<ProductCategory> ProductCategories { get; set; }
            public List<Supplier> Suppliers { get; set; }

            // Constructor to initialize the lists
            public ProductViewModel()
            {
                ProductCategories = new List<ProductCategory>();
                Suppliers = new List<Supplier>();
            }
        }

    }
}

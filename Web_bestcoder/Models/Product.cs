namespace Web_bestcoder.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}

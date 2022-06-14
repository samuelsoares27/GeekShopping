namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = String.Empty;
        public string CategoryName { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}

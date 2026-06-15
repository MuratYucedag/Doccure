namespace Doccure.WebUI.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

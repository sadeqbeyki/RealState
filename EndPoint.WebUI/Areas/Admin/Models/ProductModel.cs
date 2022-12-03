namespace RS.Contracts.Products;

public class ProductDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public long CategoryId { get; set; }
    public List<ProductViewModel> Products { get; set; }
}

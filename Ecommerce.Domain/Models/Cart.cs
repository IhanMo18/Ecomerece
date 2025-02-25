namespace Ecommerce.Domain.Models;

public class Cart
{
    public int CartId { get; set; }
    public int ProductQuantity { get; set; }
    public String SessionId { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Products>? Products { get; set; }
}
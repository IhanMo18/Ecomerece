using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Dashboard.Models;

public class Cart
{
    public int CartId { get; set; }
    public int ProductQuantity { get; set; }
    public String SessionId { get; set; }
  
    
    
    [ValidateNever]
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    [ValidateNever]
    public ICollection<Products>? Products { get; set; }
}
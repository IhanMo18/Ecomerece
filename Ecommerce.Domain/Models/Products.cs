using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;

public class Products
{
    
    [Key][Required]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Product Name")]
    public String Name { get; set; }
    [Required]  
    [Display(Name = "Product Details")]
    public String Details { get; set; }
    [Required] 
    [Display(Name = "Price")]
    public double Price { get; set; }
    [Display(Name = "Discount if have")]
    public int Discount { get; set; }
    [Display(Name = "Stock Quantity")]
    [Required] 
    public int InExist{ get; set;}
    [Display(Name = "Product Image")]
    public string ImgUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public ICollection<Reviews> reviews { get; set; }
    public int?  CartId { get; set; }
    public Cart Cart { get; set; }
}
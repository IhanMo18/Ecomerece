using System.ComponentModel.DataAnnotations;
using System.Security;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Dashboard.Models;

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
    [ValidateNever]
    [Display(Name = "Discount if have")]
    public int Discount { get; set; }
    
    
    [Display(Name = "Stock Quantity")]
    [Required] 
    public int InExist{ get; set;}
    
    [ValidateNever][Display(Name = "Product Image")]
    public string ImgUrl { get; set; }
    
    
    public int CategoryId { get; set; }
    
    
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    
    public ICollection<OrderDetail> OrderDetails { get; set; }
    [ValidateNever]
    public ICollection<Reviews> reviews { get; set; }
    
    [ValidateNever]
    public int?  CartId { get; set; }
    [ValidateNever]
    public Cart Cart { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required][Display(Name = "User Type")]
    public UserType UserType{ get; set; }
    
    [Required][MaxLength(15)][Display(Name = "Username")]
    public String Username{ get; set; }
    
    [Required][MinLength(8)][MaxLength(15)][Display(Name = "Password")]
    public String Password{ get; set; }
    
    [Required][EmailAddress][Display(Name = "Email Address")]
    public  String Email{ get; set; }
    
    public bool AccountStatus{ get; set; }
    public String ImgProfile{ get; set; }

    public ICollection<Order> Order{ get; set; }
    public ICollection<Notifications> Notifications{ get; set; }
    
    public ICollection<Reviews> Reviews{ get; set; }
    
    public Cart Cart { get; set; }
    
    
}
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;

public class Reviews
{
    [Key]
    public int IdReview { get; set; }
    public DateTime Date { get; set; }
    public int Stars { get; set; }
    
    public string Message { get; set; }
    public int ProductId { get; set; }
    public Products Product { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
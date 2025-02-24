using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models;

public class Order
{
    [Key]
    public int IdOrder{ get; set; }
    public String Gui { get; set; }
    public int UserId { get; set; }
    public User User{ get; set; }
    public int OrderDetailId { get; set; }
    public ICollection<OrderDetail> OrderDetail { get; set; }
    public OrderStatus Status { get; set; }
}
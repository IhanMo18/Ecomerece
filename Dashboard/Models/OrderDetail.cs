using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models;

public class OrderDetail
{
    [Key]
    public int IdOrderDetail{ get; set; }
    public DateTime Date { get; set; }
    public decimal PriceTotal { get; set; }
    public int Quantity { get; set; }
  
    public int OrderId { get; set; }
    public Order Order{ get; set; }

    public int ProductId;
    public Products Product{ get; set; }
   
    
}
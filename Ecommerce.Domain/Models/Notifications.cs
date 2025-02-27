using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;

public class Notifications
{
    [Key]
    public int NotificationsId  { get; set; }
    public String Message { get; set; }
    public DateTime Date { get; set; }
    public bool Read { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

}
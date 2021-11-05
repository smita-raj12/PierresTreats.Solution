using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public string TreatName { get; set; }
    public string FlavorName { get; set; }
    public virtual ApplicationUser User { get; set; }
    
  }
}
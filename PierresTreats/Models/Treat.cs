using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<TreatFlavor>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryRecipe> JoinEntities { get; set; }
  }
}
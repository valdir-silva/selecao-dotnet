using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Subscription
  {
    public int Id { get; set; }
    public bool Active { get; set; }
    public decimal Price { get; set; }

    // FK
    public int StudentId { get; set; }
    public Student Student { get; set; }
  }
}

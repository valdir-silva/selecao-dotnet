using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Card
  {
    public int Id { get; set; }
    public string Number { get; set; }

    // FK
    public int StudentId { get; set; }
    public Student Student { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Payment
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }

    // FK
    public int StudentId { get; set; }
    public Student Student { get; set; }
  }
}

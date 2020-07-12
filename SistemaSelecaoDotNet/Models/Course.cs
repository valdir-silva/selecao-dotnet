using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Course
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    // FK
    public List<Enrolment> Enrolments { get; set; }
  }
}

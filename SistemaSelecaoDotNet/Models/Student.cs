using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }

    // FK
    public Subscription Subscription { get; set; }
    public List<Enrolment> Enrolments { get; set; }
    public Card Card { get; set; }
    public List<Payment> Payments { get; set; }
    public User user { get; set; }
  }
}

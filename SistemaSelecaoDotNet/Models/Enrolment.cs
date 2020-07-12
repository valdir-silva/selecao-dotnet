using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Models
{
  public class Enrolment
  {
    public int Id { get; set; }
    public String Date { get; set; }
    //public DateTime CreateDate { get; set; }

    // FK
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
  }
}

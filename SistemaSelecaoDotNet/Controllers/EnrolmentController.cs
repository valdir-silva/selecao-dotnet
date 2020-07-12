using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSelecaoDotNet.Data;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Controllers
{
  public class EnrolmentController : Controller
  {
    private readonly StoreDataContext _context;

    public EnrolmentController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/enrolments")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Enrolment> Get()
    {
      return _context.Enrolments.AsNoTracking().ToList();
    }

    [Route("api/enrolments/{id}")]
    [HttpGet]
    public Enrolment Get(int id)
    {
      Enrolment enrolment = _context.Enrolments.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
      enrolment.Course = _context.Coursies.AsNoTracking().Where(x => x.Id == enrolment.CourseId).FirstOrDefault();
      enrolment.Student = _context.Students.AsNoTracking().Where(x => x.Id == enrolment.StudentId).FirstOrDefault();
      return enrolment;
    }
    /*
    [Route("v1/categories/{id}/products")]
    [HttpGet]
    [ResponseCache(Duration = 30)]
    public IEnumerable<Product> GetProducts(int id)
    {
      return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
    }
    */

    /*
    [Route("api/enrolments")]
    [HttpPost]
    public Enrolment Post([FromBody] Enrolment enrolment)
    {
      _context.Enrolments.Add(enrolment);
      _context.SaveChanges();

      return enrolment;
    }
    */

    [Route("api/enrolments")]
    [HttpPut]
    public Enrolment Put([FromBody] Enrolment enrolment)
    {
      _context.Entry<Enrolment>(enrolment).State = EntityState.Modified;
      _context.SaveChanges();

      return enrolment;
    }

    [Route("api/enrolments")]
    [HttpDelete]
    public Enrolment Delete([FromBody] Enrolment enrolment)
    {
      _context.Enrolments.Remove(enrolment);
      _context.SaveChanges();

      return enrolment;
    }

    // Services

    [Route("api/enrolments")]
    [HttpPost]
    [ResponseCache(Duration = 3600)]
    public IActionResult Authenticate([FromBody] Enrolment _enrolment)
    {
      Student student = _context.Students.Where(x => x.Id == _enrolment.StudentId).FirstOrDefault();
      _enrolment.Course = _context.Coursies.Where(x => x.Id == _enrolment.CourseId).FirstOrDefault();

      if (student == null)
      {
        return BadRequest(new { message = "Student not found" });
      }

      student.Payments = _context.Payments.Where(x => x.StudentId == student.Id).ToList();
      if (student.Payments == null)
      {
        return BadRequest(new { message = "Student has no payment" });
      }

      return Ok(new
      {
        Id = _enrolment.Id,
        CourseTitle = _enrolment.Course.Title
      });
    }
  }
}

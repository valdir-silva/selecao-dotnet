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
  public class StudentController : Controller
  {
    private readonly StoreDataContext _context;

    public StudentController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/students")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Student> Get()
    {
      return _context.Students.AsNoTracking().ToList();
    }

    [Route("api/students/{id}")]
    [HttpGet]
    public Student Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Students.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
    [Route("api/students")]
    [HttpPost]
    public Student Post([FromBody] Student student)
    {
      _context.Students.Add(student);
      _context.SaveChanges();

      return student;
    }

    [Route("api/students")]
    [HttpPut]
    public Student Put([FromBody] Student student)
    {
      _context.Entry<Student>(student).State = EntityState.Modified;
      _context.SaveChanges();

      return student;
    }

    [Route("api/students")]
    [HttpDelete]
    public Student Delete([FromBody] Student student)
    {
      _context.Students.Remove(student);
      _context.SaveChanges();

      return student;
    }
  }
}

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
  public class CourseController : Controller
  {
    private readonly StoreDataContext _context;

    public CourseController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/coursies")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Course> Get()
    {
      return _context.Coursies.AsNoTracking().ToList();
    }

    [Route("api/coursies/{id}")]
    [HttpGet]
    public Course Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Coursies.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
    [Route("api/coursies")]
    [HttpPost]
    public Course Post([FromBody] Course course)
    {
      _context.Coursies.Add(course);
      _context.SaveChanges();

      return course;
    }

    [Route("api/coursies")]
    [HttpPut]
    public Course Put([FromBody] Course course)
    {
      _context.Entry<Course>(course).State = EntityState.Modified;
      _context.SaveChanges();

      return course;
    }

    [Route("api/coursies")]
    [HttpDelete]
    public Course Delete([FromBody] Course course)
    {
      _context.Coursies.Remove(course);
      _context.SaveChanges();

      return course;
    }
  }
}

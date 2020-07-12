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
  public class UserController : Controller
  {
    private readonly StoreDataContext _context;

    public UserController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/users")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<User> Get()
    {
      return _context.Users.AsNoTracking().ToList();
    }

    [Route("api/users/{id}")]
    [HttpGet]
    public User Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Users.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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

    
    [Route("api/users")]
    [HttpPost]
    public User Post([FromBody] User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();

      return user;
    }
    

    [Route("api/users")]
    [HttpPut]
    public User Put([FromBody] User user)
    {
      _context.Entry<User>(user).State = EntityState.Modified;
      _context.SaveChanges();

      return user;
    }

    [Route("api/users")]
    [HttpDelete]
    public User Delete([FromBody] User user)
    {
      _context.Users.Remove(user);
      _context.SaveChanges();

      return user;
    }

    // Services

    [Route("api/authenticate")]
    [HttpPost]
    [ResponseCache(Duration = 3600)]
    public IActionResult Authenticate([FromBody] User _user)
    {
      User user = _context.Users.Where(x => x.Login == _user.Login && x.Password == _user.Password).FirstOrDefault();

      if (user == null)
      {
        return BadRequest(new { message = "Username or password is incorrect" });
      }
      else
      {
        return Ok(new
        {
          Id = user.Id,
          FirstName = user.Login
        });
      }
    }
  }
}

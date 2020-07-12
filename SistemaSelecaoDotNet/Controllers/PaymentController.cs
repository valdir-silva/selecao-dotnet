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
  public class PaymentController : Controller
  {
    private readonly StoreDataContext _context;

    public PaymentController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/payments")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Payment> Get()
    {
      return _context.Payments.AsNoTracking().ToList();
    }

    [Route("api/payments/{id}")]
    [HttpGet]
    public Payment Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Payments.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
    [Route("api/payments")]
    [HttpPost]
    public Payment Post([FromBody] Payment payment)
    {
      _context.Payments.Add(payment);
      _context.SaveChanges();

      return payment;
    }

    [Route("api/payments")]
    [HttpPut]
    public Payment Put([FromBody] Payment payment)
    {
      _context.Entry<Payment>(payment).State = EntityState.Modified;
      _context.SaveChanges();

      return payment;
    }

    [Route("api/payments")]
    [HttpDelete]
    public Payment Delete([FromBody] Payment payment)
    {
      _context.Payments.Remove(payment);
      _context.SaveChanges();

      return payment;
    }
  }
}

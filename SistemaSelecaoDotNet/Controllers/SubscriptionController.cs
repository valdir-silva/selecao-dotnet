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
  public class SubscriptionController : Controller
  {
    private readonly StoreDataContext _context;

    public SubscriptionController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/subsctiptions")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Subscription> Get()
    {
      return _context.Subscriptions.AsNoTracking().ToList();
    }

    [Route("api/subsctiptions/{id}")]
    [HttpGet]
    public Subscription Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Subscriptions.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
    [Route("api/subsctiptions")]
    [HttpPost]
    public Subscription Post([FromBody] Subscription subscription)
    {
      _context.Subscriptions.Add(subscription);
      _context.SaveChanges();

      return subscription;
    }

    [Route("api/subsctiptions")]
    [HttpPut]
    public Subscription Put([FromBody] Subscription subscription)
    {
      _context.Entry<Subscription>(subscription).State = EntityState.Modified;
      _context.SaveChanges();

      return subscription;
    }

    [Route("api/subsctiptions")]
    [HttpDelete]
    public Subscription Delete([FromBody] Subscription subscription)
    {
      _context.Subscriptions.Remove(subscription);
      _context.SaveChanges();

      return subscription;
    }

    // Services


  }
}

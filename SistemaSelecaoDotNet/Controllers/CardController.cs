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
  public class CardController : Controller
  {
    private readonly StoreDataContext _context;

    public CardController(StoreDataContext context)
    {
      _context = context;
    }

    [Route("api/cards")]
    [HttpGet]
    [ResponseCache(Duration = 3600)]
    public IEnumerable<Card> Get()
    {
      return _context.Cards.AsNoTracking().ToList();
    }

    [Route("api/cards/{id}")]
    [HttpGet]
    public Card Get(int id)
    {
      // Find() ainda não suporta AsNoTracking
      return _context.Cards.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
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
    [Route("api/cards")]
    [HttpPost]
    public Card Post([FromBody] Card card)
    {
      _context.Cards.Add(card);
      _context.SaveChanges();

      return card;
    }

    [Route("api/cards")]
    [HttpPut]
    public Card Put([FromBody] Card card)
    {
      _context.Entry<Card>(card).State = EntityState.Modified;
      _context.SaveChanges();

      return card;
    }

    [Route("api/cards")]
    [HttpDelete]
    public Card Delete([FromBody] Card card)
    {
      _context.Cards.Remove(card);
      _context.SaveChanges();

      return card;
    }
  }
}

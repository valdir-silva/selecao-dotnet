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
  public class WebApiController : Controller
  {
      private readonly StoreDataContext _context;

      public WebApiController(StoreDataContext context)
      {
        _context = context;
      }

     

  }
}

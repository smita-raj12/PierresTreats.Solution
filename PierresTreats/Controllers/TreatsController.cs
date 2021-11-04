using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Treatization;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;

    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }
     [AllowAnonymous]
    public ActionResult Index()
    {
      IQueryable<Treat> userTreats = _db.Treats.OrderBy(nameof => name.Name);
      if (!string.IsNullOrEmpty(searchString))
            {
                userTreats = userTreats
                        .Where(name => name.Name.Contains(searchString));
            }
      return View(userTreats.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
  
    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}    
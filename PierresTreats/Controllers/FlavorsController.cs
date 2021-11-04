using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresTreats.Models;

namespace PierresTreats.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly PierresTreatsContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(
            UserManager<ApplicationUser> userManager,
            PierresTreatsContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index(string searchString)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            IQueryable<Flavor> userFlavors =
                _db
                    .Flavors
                    .Where(entry => entry.User.Id == currentUser.Id)
                    .OrderBy(name => name.Name);
            if (!string.IsNullOrEmpty(searchString))
            {
                userFlavors =
                    userFlavors
                        .Where(name => name.Name.Contains(searchString));
            }
            return View(userFlavors.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor, int TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Flavor.User = currentUser;
            _db.Flavors.Add (flavor);
            _db.SaveChanges();
            if (TreatId != 0)
            {
                _db.TreatFlavor.Add(new TreatFlavor(){ TreatId = TreatId, FlavorId = Flavor.FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}        
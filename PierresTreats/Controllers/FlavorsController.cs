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
    }
}        
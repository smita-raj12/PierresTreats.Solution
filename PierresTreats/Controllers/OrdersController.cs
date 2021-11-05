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
    public class OrdersController : Controller
    {
        private readonly PierresTreatsContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(UserManager<ApplicationUser> userManager, PierresTreatsContext db )
        {
            _userManager = userManager;
            _db = db;
        }

        [Authorize(Roles = "User")]
        public ActionResult Index(string searchString)
        {
            IQueryable<Order> userOrders = _db.Orders.OrderBy(name => name.TreatName);
            if (!string.IsNullOrEmpty(searchString))
            {
                userOrders = userOrders.Where(name => name.TreatName.Contains(searchString));
            }
            return View(userOrders.ToList());
        }

        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult> Create(Order Order)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Order.User = currentUser;
            _db.Orders.Add (Order);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            var thisOrder =_db.Orders.FirstOrDefault(order => order.OrderId == id);
            return View(thisOrder);
        }

        [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            var thisOrder = _db.Orders.FirstOrDefault(Order => Order.OrderId == id);
            return View(thisOrder);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult Edit(Order Order)
        {
            _db.Entry(Order).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "User")]
        public ActionResult Delete(int id)
        {
            var thisOrder = _db.Orders.FirstOrDefault(Order => Order.OrderId == id);
            return View(thisOrder);
        }
        
        [Authorize(Roles = "User")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisOrder = _db.Orders.FirstOrDefault(Order => Order.OrderId == id);
            _db.Orders.Remove (thisOrder);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}        
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp1.Models;
using BookStoreApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp1.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreDbContext context;

        public HomeController(BookStoreDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //model.Userid = 1;

            context.Users.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

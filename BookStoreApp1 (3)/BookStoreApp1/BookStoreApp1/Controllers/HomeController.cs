using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp1.Models;
using BookStoreApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
            var list = context.Books.Where(x => x.IsActive == true).ToList();

            if (list.Count() == 0)
            {
                BookModel defaultbook = new BookModel()
                {
                    Title = "Add a book to the database my friend",
                    Author = "Ed Taylor",
                    Desc = "This is a default hardcoded book. This will disappear when you add your first book!",
                    Price = 0.99m,
                    IsActive = true,
                    BookId = 1
                };
            }

            return View(list);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(VmUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserModel newuser = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                State = model.State,
                PostalCode = model.PostalCode,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = false,
            };

            context.Users.Add(newuser);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VmLoginModel model)
        {
            List<UserModel> users = context.Users.Where(x => x.Username == model.Username && x.Password == model.Password).ToList();
            
            if (users.Count() > 0)
            {
                TempData["Name"] = users.FirstOrDefault().FirstName + " " + users.FirstOrDefault().LastName;
                TempData["Admin"] = users.FirstOrDefault().IsAdmin.ToString();
                
            }

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

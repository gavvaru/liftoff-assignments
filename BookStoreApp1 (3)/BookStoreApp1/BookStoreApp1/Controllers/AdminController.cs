using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp1.Models;
using BookStoreApp1.Data;

namespace BookStoreApp1.Controllers
{
    public class AdminController : Controller
    {
        private BookStoreDbContext context;

        public AdminController(BookStoreDbContext dbContext)
        {
            this.context = dbContext;
        }

        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.IsActive = true;

            context.Books.Add(model);
            context.SaveChanges();

            return RedirectToAction("index","home");
        }

        public ActionResult BookList()
        {
            var list = context.Books.ToList();

            return View(list);
        }

        public ActionResult Delete(int id)
        {
            BookModel model = context.Books.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(BookModel model)
        {
            BookModel removeBook = context.Books.Find(model.BookId);

            removeBook.IsActive = false;
            context.SaveChanges();

            return RedirectToAction("index", "home");
        }
    }
}
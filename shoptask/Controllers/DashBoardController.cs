using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoptask.Data;
using shoptask.Models;
using System.Reflection.Metadata.Ecma335;

namespace shoptask.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Product> _products = new List<Product>();
        private static List<Company> _company = new List<Company>();
        private static List<Blog> _blogs = new List<Blog>();
        private static List<Typeb> _types = new List<Typeb>();
        private readonly ApplicationDbContext _db;
        public DashBoardController(ApplicationDbContext db)
        {
            _company.Add(new Company { Id = 1, Name = "Niki" });
            _company.Add(new Company { Id = 2, Name = "Adidas" });
            _types.Add(new Typeb { Id = 1, Name = "comedy" });
            _types.Add(new Typeb { Id = 2, Name = "drama" });
            _types.Add(new Typeb { Id = 3, Name = "Action" });
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
           _db.products.Add(product);
           _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ViewProduct()
        {
            var product = _db.products.Include(p => p.company).ToList();
            return View(product);

        }
        public IActionResult Delete(int id)
        {
            Product? product = _db.products.FirstOrDefault(x => x.Id == id);

            _db.products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("ViewProduct");
        }
        public IActionResult Edite(int id)
        {
            Product product = _db.products.FirstOrDefault(x => x.Id == id);

            return View(product);
        }
        [HttpPut]
        public IActionResult Edite(Product product)
        {
            Product temp = _db.products.SingleOrDefault(c => c.Id == product.Id);
            temp.Name = product.Name;
            temp.Description = product.Description;
            temp.Price = product.Price;
            temp.EnableSize = product.EnableSize;
            temp.Quantity = product.Quantity;
            temp.companyID = product.companyID;
            _db.products.Update(temp);
            _db.SaveChanges();
            return RedirectToAction("ViewProduct");
        }
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ViewBlog()
        {
            var blog = _db.blogs.Include(p=>p.type).ToList();
            return View(blog);
        }
        public IActionResult DeleteBlog(int id)
        {
            Blog blog = _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return RedirectToAction("ViewBlog");

        }
        public IActionResult EditBlog(int id)
        {
            Blog blog = _db.blogs.FirstOrDefault(y => y.Id == id);

            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {

            Blog pl=_db.blogs.SingleOrDefault(c=>c.Id == blog.Id);
            pl.Name = blog.Name;
            pl.Price = blog.Price;
            pl.Description= blog.Description;
            pl.Quantity = blog.Quantity;
            pl.typeID = blog.typeID;
            _db.blogs.Update(pl);
            _db.SaveChanges();

            return RedirectToAction("ViewBlog");
        }


    }
}

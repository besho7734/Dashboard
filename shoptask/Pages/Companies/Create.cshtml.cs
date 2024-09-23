using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shoptask.Data;
using shoptask.Models;

namespace shoptask.Pages.Companies
{
    public class CreateModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.companies.Add(Company);
            _db.SaveChanges();
            return RedirectToPage("Viewcompany");
        }
    }
}

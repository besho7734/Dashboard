using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shoptask.Data;
using shoptask.Models;

namespace shoptask.Pages.Companies
{
    public class EditeModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        public void OnGet(int id)
        {
            Company=_db.companies.FirstOrDefault(x => x.Id == id);
        }
        public IActionResult OnPost()
        {
            var oldCompany=_db.companies.FirstOrDefault(x=>x.Id == Company.Id);
            oldCompany.Name=Company.Name;

            _db.SaveChanges();
            return RedirectToPage("Viewcompany");
        }
    }
}

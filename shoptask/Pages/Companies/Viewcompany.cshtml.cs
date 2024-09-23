using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shoptask.Data;
using shoptask.Models;

namespace shoptask.Pages.Companies
{
    public class ViewcompanyModel(ApplicationDbContext _db) : PageModel
    {
        public List<Company> AllCompany {  get; set; } 
        public void OnGet()
        {
            AllCompany = _db.companies.ToList();
        }
    }
}

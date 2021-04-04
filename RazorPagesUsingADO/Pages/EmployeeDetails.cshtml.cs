using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUsingADO.Models;

namespace RazorPagesUsingADO.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        readonly EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        public Employee Employee { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/NotFound");
            }
            Employee = objemployee.GetEmployeeData(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUsingADO.Models;

namespace RazorPagesUsingADO.Pages
{
    public class CreateEmployeeModel : PageModel
    {
        readonly EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [BindProperty]
        public Employee Employee { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            objemployee.AddEmployee(Employee);

            return RedirectToPage("./EmployeeIndex");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUsingADO.Models;

namespace RazorPagesUsingADO.Pages
{
    public class EditEmployeeModel : PageModel
    {
        readonly EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [BindProperty]
        public Employee Employee { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = objemployee.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objemployee.UpdateEmployee(Employee);

            return RedirectToPage("./EmployeeIndex");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUsingADO.Models;

namespace RazorPagesUsingADO.Pages
{
    public class DeleteEmployeeModel : PageModel
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
        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/NotFound");
            }
            objemployee.DeleteEmployee(id);
            return RedirectToPage("./EmployeeIndex");
        }
    }
}
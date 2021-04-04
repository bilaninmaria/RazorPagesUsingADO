using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUsingADO.Models;

namespace RazorPagesUsingADO.Pages
{
    public class EmployeeIndexModel : PageModel
    {
        readonly EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        public List<Employee> Employee { get; set; }
        public void OnGet()
        {
            Employee = objemployee.GetAllEmployees().ToList();
        }
    }
}
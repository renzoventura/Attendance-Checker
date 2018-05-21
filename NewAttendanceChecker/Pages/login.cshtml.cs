using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewAttendanceChecker.Data;

namespace NewAttendanceChecker.Pages
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public string UPI { get; set; }
        private ApplicationDbContext _context;
        public loginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var student =  _context.Students.FirstOrDefault(p=>p.StudentID==UPI);
            if (student!=null)
            {
                return RedirectToPage("Student",new { UPI=UPI});
            }

            var lecturer = _context.Lecturers.FirstOrDefault(l => l.Name == UPI);
            if (lecturer!=null){
                return RedirectToPage("Lecturer", new { Name = UPI });
            }
            return RedirectToPage();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewAttendanceChecker.Data;
using NewAttendanceChecker.Data.Models;

namespace NewAttendanceChecker.Pages
{
    public class StudentModel : PageModel
    {
        private ApplicationDbContext _context;
        public Student Student { get; set; }
        public IList<Attendance> AttendanceList { get; set; }
        public IList<Session> Sessions { get; set; }
        public StudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync( string UPI)
        {
            Student = _context.Students
                .Include(s => s.AttendanceList)
                .Include(s => s.CourseTags)
                    .ThenInclude(s => s.Course)
                        .ThenInclude(s => s.Lecturer)
                .FirstOrDefault(s => s.StudentID == UPI);
            
            AttendanceList = _context.AttendanceList
                .Include(a => a.Session)
                    .ThenInclude(s => s.Course)
                .Where(a=>a.StudentID==UPI)
                .ToList();
            Sessions = _context.Sessions
                .Where(s=>Student.CourseTags.Select(c=>c.CourseID).Contains(s.CourseID)) //only sessions of my courses
                .Where(s=>!AttendanceList.Select(a=>a.SessionID).Contains(s.SessionID))
                .ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string checkInCode, string UPI, string realCode)
        {
            Attendance Attendance;
            
            if (checkInCode != null)
            {
                if (checkInCode.ToLower() == realCode.ToLower())
                {
                    Attendance = new Attendance
                    {
                        StudentID = UPI,
                        SessionID = realCode
                    };
                    await _context.AttendanceList.AddAsync(Attendance);
                    await _context.SaveChangesAsync();
                }
                

            }
            return RedirectToPage();
        }

    }
}
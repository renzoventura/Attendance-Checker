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
    public class LecturerModel : PageModel
    {
        private ApplicationDbContext _context;
        public Lecturer Lecturer { get; set; }
       
        public LecturerModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string Name)
        {
            Lecturer = _context.Lecturers
                .Include(l=>l.Course)
                .ThenInclude(c=>c.Sessions)
                .FirstOrDefault(s => s.Name == Name);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id, double lng, double lat)
        {
            var allSessionIDs = _context.Sessions.Select(s => s.SessionID).ToList();
            String sessionCode = GenerateCode();
            while (allSessionIDs.Contains(sessionCode))
            {
                sessionCode = GenerateCode();
            }
            Session Session = new Session
            {
                SessionID = sessionCode,
                CourseID = id,
                Latitude = lat,
                Longitude = lng
            };
            await _context.Sessions.AddAsync(Session);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
        public string GenerateCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
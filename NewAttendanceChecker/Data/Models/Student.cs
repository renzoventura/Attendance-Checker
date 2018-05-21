using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAttendanceChecker.Data.Models
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public ICollection<CourseTag> CourseTags { get; set; }
        public ICollection<Attendance> AttendanceList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewAttendanceChecker.Data.Models
{
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        public string Name { get; set; }

        
        public Lecturer Lecturer { get; set; }
        public ICollection<CourseTag> CourseTags { get; set; }
        public ICollection<Session> Sessions { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewAttendanceChecker.Data.Models
{
    public class Lecturer
    {
        [Key]
        [ForeignKey("Course")]
        public string LecturerID { get; set; }
        public string Name { get; set; }

        public Course Course { get; set; }
        
    }
}

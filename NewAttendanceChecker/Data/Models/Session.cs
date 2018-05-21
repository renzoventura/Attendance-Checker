using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewAttendanceChecker.Data.Models
{
    public class Session
    {
        [Key]
        public string SessionID { get; set; }
        public string CourseID { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        public ICollection<Attendance> AttendanceList { get; set; }
    


    }
}

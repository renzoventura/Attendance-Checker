using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewAttendanceChecker.Data.Models
{
    public class Attendance
    {
        [Key]
        public string AttendanceID { get; set; }
        public string StudentID { get; set; }
        public string SessionID { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }
        [ForeignKey("SessionID")]
        public Session Session { get; set; }
    }
}

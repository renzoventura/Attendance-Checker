using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NewAttendanceChecker.Data.Models;

namespace NewAttendanceChecker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendance> AttendanceList { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public static async Task PopulateData(IServiceProvider services)
        {
            Course Course;
            Lecturer Lecturer;
            var context = services.GetRequiredService<ApplicationDbContext>();
            List<string> fixedListCourses = new List<string> { "COMPSCI101","COMPSCI105","COMPSCI111","COMPSCI220", "COMPSCI230", "COMPSCI225", "COMPSCI335", "COMPSCI320" }.OrderBy(q => q).ToList();
            List<string> fixedListLecturers = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" }.OrderBy(q => q).ToList();
            List<string> fixedListStudents = new List<string> { "kngu576", "riss899", "vtan618", "even069" }.ToList();
            List<string> fixedListNames = new List<string> { "Khoa", "Rahul", "Paul", "Renzo" }.ToList();

            var courses = context.Courses.Select(c => c.Name);
            var lecturers = context.Lecturers.Select(c => c.Name);
            
            for (int i = 0; i < fixedListLecturers.Count(); i++)
            {
                if (!lecturers.Contains(fixedListLecturers.ElementAt(i)))
                {
                   

                    Lecturer = new Lecturer
                    {
                        Name = fixedListLecturers.ElementAt(i)
                   
                    };
                    Course = new Course
                    {
                        Name = fixedListCourses.ElementAt(i)
                    };
                    Lecturer.Course = Course;
                    Course.Lecturer = Lecturer;
                    await context.Courses.AddAsync(Course);
                    await context.Lecturers.AddAsync(Lecturer);
                }
            }
            await context.SaveChangesAsync();

            Student Student;
            CourseTag CourseTag;
            Random random = new Random();
            int ranNum;
            var allCourses = context.Courses.ToList();
            List<Course> randomCourses;
            List<CourseTag> CourseTags;
            var students = context.Students.Select(c => c.StudentID);
            for(int i=0;i<fixedListStudents.Count();i++)
            {
                var student = fixedListStudents.ElementAt(i);
                if (!students.Contains(student))
                {
                    Student = new Student
                    {
                        StudentID=student,
                        Name = fixedListNames.ElementAt(i),
                        Points = 0
                    };
                    CourseTags = new List<CourseTag> { };
                    randomCourses = new List<Course> { };
                    while (CourseTags.Count() < 3)
                    {
                        ranNum = random.Next(0, context.Courses.Count());
                        Course = allCourses.ElementAt(ranNum);
                        if (!randomCourses.Contains(Course))
                        {
                            CourseTag = new CourseTag
                            {
                                Course=Course,
                                Student = Student
                            };
                            CourseTags.Add(CourseTag);
                            await context.CourseTags.AddAsync(CourseTag);
                            randomCourses.Add(Course);
                        }

                    }
                   
                    await context.Students.AddAsync(Student);




                }
            }
            await context.SaveChangesAsync();
        }
        public static async Task PopulateStudents(IServiceProvider services)
        {
            Student Student;
            var context = services.GetRequiredService<ApplicationDbContext>();
            List<string> fixedList = new List<string> { "kngu576", "riss899", "vtan618", "even069"}.OrderBy(q => q).ToList();
            var students = context.Students.Select(c => c.Name);
            var allCourses = context.Courses;
            List<Course> randomCourses;
            Random random = new Random();
            int ranNum;
            foreach (var student in fixedList)
            {
                if (!students.Contains(student))
                {
                    randomCourses = new List<Course> { };
                    while (randomCourses.Count() < 3)
                    {   
                        ranNum = random.Next(0, context.Courses.Count());
                        if (!randomCourses.Contains(allCourses.ElementAt(ranNum)))
                        {
                            randomCourses.Add(allCourses.ElementAt(ranNum));
                        }

                    }


                    Student = new Student {
                        Name = student
                    };
                    context.Students.Add(Student);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}

using System;
using System.Linq;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore; // 為了使用 Migrate()

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // 若不需要自動遷移，可以註解這行
        // context.Database.Migrate();

        // --- Instructor 隨機產生 ---
        if (!context.Instructor.Any())
        {
            var random = new Random();
            string[] firstNames = { "John", "Mary", "Alex", "Linda", "James", "Susan", "Robert", "Karen" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Lee", "Clark", "Wang", "Garcia", "Chen" };

            var instructors = Enumerable.Range(1, 5).Select(i => new Instructor
            {
                FirstMidName = firstNames[random.Next(firstNames.Length)],
                LastName = lastNames[random.Next(lastNames.Length)],
                HireDate = DateTime.Now.AddYears(-random.Next(1, 20)).AddDays(random.Next(365))
            }).ToArray();

            context.Instructor.AddRange(instructors);
            context.SaveChanges();
        }

        // --- Department 隨機產生 ---
        if (!context.Department.Any())
        {
            var random = new Random();
            string[] deptNames = { "Math", "Physics", "Chemistry", "Biology", "Economics", "History", "Music", "CS" };
            var instructors = context.Instructor.ToList();

            var departments = Enumerable.Range(1, 5).Select(i => new Department
            {
                Name = deptNames[random.Next(deptNames.Length)],
                Chair = instructors[random.Next(instructors.Count)].FullName // 假設Chair是string
            }).ToArray();

            context.Department.AddRange(departments);
            context.SaveChanges();
        }

        // --- Student 初始化 ---
        if (!context.Students.Any())
        {
            var students = new Student[]
            {
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
        }

        // --- Course 初始化 ---
        if (!context.Courses.Any())
        {
            var courses = new Course[]
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4 },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        // --- Enrollment 初始化 ---
        if (!context.Enrollments.Any())
        {
            var students = context.Students.ToArray();
            var courses = context.Courses.ToArray();

            var enrollments = new Enrollment[]
            {
                new Enrollment { StudentID = students[0].ID, CourseID = courses[0].CourseID, Grade = Grade.A },
                new Enrollment { StudentID = students[0].ID, CourseID = courses[1].CourseID, Grade = Grade.C },
                new Enrollment { StudentID = students[0].ID, CourseID = courses[2].CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[3].CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[4].CourseID, Grade = Grade.F },
                new Enrollment { StudentID = students[1].ID, CourseID = courses[5].CourseID, Grade = Grade.F },
                new Enrollment { StudentID = students[2].ID, CourseID = courses[0].CourseID },
                new Enrollment { StudentID = students[3].ID, CourseID = courses[0].CourseID },
                new Enrollment { StudentID = students[3].ID, CourseID = courses[1].CourseID, Grade = Grade.F },
                new Enrollment { StudentID = students[4].ID, CourseID = courses[2].CourseID, Grade = Grade.C },
                new Enrollment { StudentID = students[5].ID, CourseID = courses[3].CourseID },
                new Enrollment { StudentID = students[6].ID, CourseID = courses[4].CourseID, Grade = Grade.A }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

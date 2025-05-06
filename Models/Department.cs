using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }         // 系別主鍵
        public string Name { get; set; } = string.Empty; // 系名
        public decimal Budget { get; set; }           // 預算
        public DateTime StartDate { get; set; }       // 成立日期

        // 系主任（可為 null）
        public int? InstructorID { get; set; }        // 系主任的教師ID（外鍵，可為 null）
        public Instructor? Administrator { get; set; } // 系主任的導覽屬性

        // 系所開設的課程
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }

        public string? Chair { get; set; } // 主任

        // 系下的所有老師
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }

}
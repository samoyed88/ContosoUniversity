using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Chair { get; set; } = string.Empty; // 或用 int? ChairID
    }

}
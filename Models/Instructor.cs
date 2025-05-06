namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime HireDate { get; set; }

        public string? FullName => LastName + " " + FirstName;

        public ICollection<Course>? Courses { get; set; } = new List<Course>();

        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }
    }
}

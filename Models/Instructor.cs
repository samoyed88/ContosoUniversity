namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstMidName { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string FullName => $"{LastName} {FirstMidName}";
    }
}

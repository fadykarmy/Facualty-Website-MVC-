using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Department
    {
        [Key] public int Department_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department_Name { get; set; }
        public int StudentID { get; set; }
      
        public Student Student { get; set; }
    }
}

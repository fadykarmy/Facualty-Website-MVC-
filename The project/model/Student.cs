using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Student
    {
        [Key] public int Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
      
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}

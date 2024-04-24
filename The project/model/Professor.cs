using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
 
      public class Professor
    {
        [Key] public int ProfessorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public ICollection<Course> Courses { get; set; } 
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }


    }
}

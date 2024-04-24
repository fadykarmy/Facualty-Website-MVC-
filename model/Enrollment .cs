using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_project.model
{
    public enum Grade
    {
        A, B, C, D, F
    } 
    public class Enrollment
    {
        [Key] public int EnrollmentID { get; set; }
        public int ProfessorID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
        public Professor Professor { get; set; }
    }
}



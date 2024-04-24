using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_project.model
{
    public class Course
    {

       
        [Key] public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        


    }
}
using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Lecture
    {
        [Key] public int LectureID { get; set; }
        public string Lecturename { get; set; }
        public int CourseID { get; set; }
        public int ProfessorID { get; set; }
        public Course Course { get; set; }
        public Professor Professor { get; set; }

        public ICollection<Coliseum> Coliseums { get; set; }
    }
}

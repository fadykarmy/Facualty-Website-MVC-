using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Coliseum
    {
        [Key] public int ColiseumID { get; set; }
        public int LectureID { get; set; }
        public DateTime LectureDate { get; set; }
        public Lecture Lectures { get; set; }

    }
}

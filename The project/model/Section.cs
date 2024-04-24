using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Section
    {
        [Key] public int SectionID { get; set; }
        public int CourseID { get; set; }
        public int EngineerID { get; set; }
        public Course Course { get; set; }
        public Engineer engineer { get; set; }
        public ICollection<Lab> Labs { get; set; }
    }

}

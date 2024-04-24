using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Lab
    {
        [Key] public int LabID { get; set; }
        public int SectionID { get; set; }
        public DateTime SectionDate { get; set; }
        public Section Sections { get; set; }
    }
}

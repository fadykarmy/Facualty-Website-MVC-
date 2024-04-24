using System.ComponentModel.DataAnnotations;

namespace The_project.model
{
    public class Engineer
    {
        [Key] public int Engineer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}

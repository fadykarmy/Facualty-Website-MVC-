using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_project.model
{
    public class StudentCreative
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column(Order = 1)]
        public int Code { get; set; }
        [Required]
        [DisplayName("First Name")]

        public string firstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Image")]
        [DefaultValue("default.png")]

        public string studentImgae { get; set; }

    }
}

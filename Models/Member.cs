using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClub.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembershipNumberId { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Handicap is required")]
        [Range(0, 54, ErrorMessage = "Handicap must be between 0 and 54")]
        public int Handicap { get; set; }

    }
}

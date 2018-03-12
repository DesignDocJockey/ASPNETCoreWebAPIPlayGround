using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CreatePlayerDto
    {
        [Required(ErrorMessage="First Name Required")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}

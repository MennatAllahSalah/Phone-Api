using System.ComponentModel.DataAnnotations;

namespace phoneBook.DTO
{
    public class loginDto
    {
        [Required]
        public string UserNAme { get; set; }

        [Required]
        public string PAssword { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace StudentNewApi.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}

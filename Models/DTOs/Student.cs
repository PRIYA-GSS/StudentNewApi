
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Models.DTOs
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public IFormFile File { get; set; }
    }
}

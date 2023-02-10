using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityApp.Models
{
    public class RegisterRequest
    {
        [Key]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string? Nickname { get; set; }
        public string? Phone { get; set; }
        public int StatusId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TatoSen.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
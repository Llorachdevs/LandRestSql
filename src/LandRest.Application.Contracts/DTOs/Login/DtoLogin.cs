using System.ComponentModel.DataAnnotations;

namespace LandRest.DTOs.Login
{
    public class DtoLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
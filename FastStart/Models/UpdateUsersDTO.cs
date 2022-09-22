using System.ComponentModel.DataAnnotations;

namespace FastStart.Models
{
    public class UpdateUsersDTO
    {
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Phone]
        [Display(Name = "NrTel")]
        public string NrTel { get; set; }
        public string Rola { get; set; }
    }
}

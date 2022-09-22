using System.ComponentModel.DataAnnotations;


namespace FastStart.Models
{
    public class CreateUsersDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Imie { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }
        public string DataUrodzenia { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long NrFBO { get; set; }
        [Phone]
        [Display(Name = "NrTel")]
        public string NrTel { get; set; }
        public string Rola { get; set; }

    }
}

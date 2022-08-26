using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart.Models
{
    public class UpdateUsersDTO
    {
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Phone]
        [Display(Name = "NrTel")]
        public string NrTel { get; set; }
        public string Rola { get; set; }
    }
}

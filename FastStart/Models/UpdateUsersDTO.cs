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
        [Required]
        [EmailAddress]
        public string eMail { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Phone]
        [Display(Name = "nrTel")]
        public string nrTel { get; set; }
        public string Rola { get; set; }
        public object ConfirmPassword { get; internal set; }
    }
}

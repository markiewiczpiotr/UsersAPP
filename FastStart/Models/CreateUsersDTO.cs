using FastStart.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        [Required]
        [EmailAddress]
        public string eMail { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        public long nrFBO { get; set; }
        [Phone]
        [Display(Name = "nrTel")]
        public string nrTel { get; set; }
        public string Rola { get; set; }

    }
}

/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart.Models
{
    public class RegisterUserDTO
    {
        [Required]
        [EmailAddress]
        public string eMail { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public DateTime? DataUrodzin { get; set; }
        public string Rola { get; set; }
    }
}
*/
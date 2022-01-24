using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.VM
{
    public class AdminUserVM
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}

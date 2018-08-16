using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp1.Models
{
    public class UserModel
    {
        [Key]
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class VmUserModel
    {
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }

    public class VmLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }

    public class VmUserDisplayModel
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}

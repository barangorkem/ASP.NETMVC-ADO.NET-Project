using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Models
{
    public class Users
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="UserName is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        public string Auth { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

    }
}
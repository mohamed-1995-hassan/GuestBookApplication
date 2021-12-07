using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Data.Models
{
   public class User : BaseEntity
   {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual IEnumerable<UserMessage> userMessages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Data.Models
{
   public class UserMessage : BaseEntity
   {
        [Required]
        public string Message { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<MessageReplies> MessageReplies { get; set; }
    }
}

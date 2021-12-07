using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Data.Models
{
    public class MessageReplies : BaseEntity
    {
        public string replay { get; set; }
        [ForeignKey("UserMessage")]
        public int UserMessageId { get; set; }
        public virtual UserMessage userMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Data.Models
{
   public class BaseEntity
   {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}

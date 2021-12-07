using GuestBookApplication.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Repositories.Context
{
   public class ApplicationContext :DbContext
   {
      public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
      {

      }
      public virtual DbSet<User> Users { get; set; }
      public virtual DbSet<UserMessage> UserMessages { get; set; }
      public virtual DbSet<MessageReplies> MessageReplies { get; set; }
    }
}

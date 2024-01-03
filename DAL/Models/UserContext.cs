using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Lead> Leads { get; set; }

    }

    //User -> Manager, Saler/Marketer
    //Subscription
    //Campaign
    //Notifications
    //Contact


}

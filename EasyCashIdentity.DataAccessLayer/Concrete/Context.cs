using EashCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HAMZA\\SQLEXPRESS;initial catalog=DbEasyCash; integrated Security=true");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
    }
}

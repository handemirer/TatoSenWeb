using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString());
        }

        public DbSet<User> Users { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        modelBuilder.Entity<User>.
        }
        */
    }
}

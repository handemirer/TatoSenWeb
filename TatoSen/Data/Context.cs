using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TatoSen.Model;

namespace TatoSen.Data
{
    public class Context : DbContext
    {
        public Context() { }
        //public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            String cs = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString();

            optionsBuilder.UseMySQL(connStrToArray());
            //optionsBuilder.UseMySQL("Data Source=127.0.0.1;Database=localdb;User Id=root;Password=admin");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static string connStrToArray()
        {
            string connStr = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString();
            string[] connArray = Regex.Split(connStr, ";");
            string connectionstring = null;
            for (int i = 0; i < connArray.Length; i++)
            {

                if (i == 1)
                {
                    string[] datasource = Regex.Split(connArray[i], ":");
                    connectionstring += datasource[0] + string.Format(";port={0};", datasource[1]);
                }
                else
                {
                    connectionstring += connArray[i] + ";";
                }
            }

            return connectionstring;
        }
    }
}

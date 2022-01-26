using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EntityLayer.Model;

namespace DataAccessLayer.Data
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
        public DbSet<UserPack> UserPacks { get; set; }
        public DbSet<Added> Addeds { get; set; }
        public DbSet<UserSentence> UserSentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserPack>().HasKey(table => new
            {
                table.user_pack_id,
                table.user_id,
            });
            modelBuilder.Entity<Added>().HasKey(table => new
            {
                table.pack_id,
                table.user_id,
            });
            modelBuilder.Entity<UserSentence>().HasKey(table => new
            {
                table.user_sentence_id,
            });
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

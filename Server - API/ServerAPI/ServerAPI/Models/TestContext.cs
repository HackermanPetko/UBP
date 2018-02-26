using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServerAPI.Models
{
    public class TestContext : DbContext
    { 

        public DbSet<Config> Configs { get; set; }
        public DbSet<Backup> Backups { get; set; }
        public DbSet<Daemon> Daemons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // M:N relace mezi tabulkami Person <-> Course s mezitabulkou PersonCourse
            /*modelBuilder.Entity<Person>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs => {
                    cs.MapLeftKey("PersonId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("PersonCourse");
                });*/
        }

        public User FindUser(string username)
        {
            List<User> users = this.Users.Where(x => x.Username == username).ToList();
            User user = users.First();
            
            
            return user;
        }

    }
}
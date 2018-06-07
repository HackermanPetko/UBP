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
        public DbSet<Backup> Backups { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Daemon> Daemons { get; set; }
        public DbSet<Dest> Destinations { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<BackupTask> Tasks { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlackList> BlackListed { get; set; }

        public TestContext()
        { 
            this.Configs
              .Include("Tasks")
              .ToList();

            this.Tasks
             .Include("Sources")
             .ToList();

            this.Tasks
             .Include("Destinations")
             .ToList();
        }

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
        public Token FindToken(string token)
        {
            List<Token> listTokens = this.Tokens.Where(x => x.UserToken == token).ToList();
            Token resToken = listTokens.First();


            return resToken;
        }
        public Daemon FindDaemon(string MAC)
        {
            return this.Daemons.Where(x => x.DaemonMAC == MAC).ToList().First();
        }

        public void NewConfig(int id)
        {
            this.Configs.SqlQuery($"insert into Config values (1,default,{DateTime.Now.ToString()},{DateTime.Now.ToString()})",new SqlParameter("@id",id));
            //this.Configs.Add(new Config() { Comment = "default", Id = id, LastChecked = DateTime.Now, TimeStamp = DateTime.Now });
            this.SaveChanges();
        }

        public void NewDaemon(Daemon daemon)
        {
            this.Daemons.Add(daemon);
            this.SaveChanges();
        }
    }
}
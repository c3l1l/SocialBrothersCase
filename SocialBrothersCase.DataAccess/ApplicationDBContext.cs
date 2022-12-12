using Microsoft.EntityFrameworkCore;
using SocialBrothersCase.DataAccess.ModelConfig;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.DataAccess
{  

    public  class ApplicationDBContext:DbContext
    {
       // private readonly string connectionString = "Server=.;Database=SocialBrothersCase;Trusted_Connection=True;";
        
       private readonly string connectionString = "Data Source=SQL5080.site4now.net;Initial Catalog=db_a91077_myaspnetcoretest;User Id=db_a91077_myaspnetcoretest_admin;Password=Gunes-123";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Post>(new PostCFG());
            modelBuilder.ApplyConfiguration<Category>(new CategoryCFG());
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJewels.Models;

namespace CodeJewels.Data
{
    public class CodeJewelContext : DbContext
    {
        public CodeJewelContext()
            : base("CodeJewelDb")
        {
        }

        public DbSet<CodeJewel> CodeJewels { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CodeJewel>()
            //    .HasOptional(j => j.Category)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete();
            //
            //modelBuilder.Entity<CodeJewel>()
            //    .HasOptional(j => j.Votes)
            //    .WithOptionalDependent()
            //    .WillCascadeOnDelete();
            //
            //modelBuilder.Entity<CodeJewel>()
            //    .HasKey(j => j.Id)
            //    .Property(j => j.Id)
            //    .HasColumnName("CodeJewelId");
            //
            //modelBuilder.Entity<Category>()
            //    .HasKey(c => c.Id)
            //    .Property(c => c.Id)
            //    .HasColumnName("CategoryId");
            //
            //modelBuilder.Entity<Vote>()
            //    .HasKey(v => v.Id)
            //    .Property(v => v.Id)
            //    .HasColumnName("VoteId");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

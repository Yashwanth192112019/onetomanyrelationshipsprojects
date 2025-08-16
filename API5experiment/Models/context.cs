using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using API5experiment.Models;

namespace API5experiment.Models
{
    public class context : DbContext
    {
        public context () { }

        public context (DbContextOptions<context> options) : base(options) { }

        public virtual student students { get; set; }

        public virtual teacher teachers { get; set; }

        public virtual enrollment enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source = YASH_MALLADI; database = m2mm; integrated security = true; trustservercertificate = true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<enrollment>()
                .HasKey(ba => new { ba.SId, ba.TId });
            modelBuilder.Entity<enrollment>()
                .HasOne(b => b.student)
                .WithMany(b => b.enrollments)
                .HasForeignKey(b => b.SId);
            modelBuilder.Entity<enrollment>()
                .HasOne(b => b.teacher)
                .WithMany(b => b.enrollments)
                .HasForeignKey(b => b.TId);

            modelBuilder.Entity<student>()
                .HasData(new student() { SId = 1, Description = "very good reader", SName = "ganes" },
                new student() { SId = 2, Description = "very good dancer", SName = "panis" });
            modelBuilder.Entity<teacher>()
                .HasData(new teacher() { TId = 1, TName = "yashanth", Description = " very good teacher" },
                new teacher() { TId = 2, TName = "baanes", Description = "very bbufb" });

            modelBuilder.Entity<enrollment>()
                .HasData(new enrollment() { SId = 1, TId = 2 },
                new enrollment() { SId = 2, TId = 1 });
                
        }
        public DbSet<API5experiment.Models.student> student { get; set; } = default!;
        public DbSet<API5experiment.Models.teacher> teacher { get; set; } = default!;
        public DbSet<API5experiment.Models.enrollment> enrollment { get; set; } = default!;

    }
}

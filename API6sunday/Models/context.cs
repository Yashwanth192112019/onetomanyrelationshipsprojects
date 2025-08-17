using Microsoft.EntityFrameworkCore;

namespace API6sunday.Models
{
    public class context : DbContext
    {
        public context() { }

        public context(DbContextOptions<context> options) : base(options) { }

        public DbSet<employee> emps { get; set; }

        public DbSet<department> depts { get; set; }

        public DbSet<both> both { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source = YASH_MALLADI; database = sunday; integrated security = true; trustservercertificate = true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<both>()
                .HasKey(a => new { a.id, a.Did });
            modelBuilder.Entity<both>()
                .HasOne(a => a.employee)
                .WithMany(a => a.both)
                .HasForeignKey(a => a.id);
            modelBuilder.Entity<both>()
                .HasOne(a => a.department)
                .WithMany(a => a.both)
                .HasForeignKey(a => a.Did);

            modelBuilder.Entity<employee>()
                .HasData(new employee { Id = 1, Name = "yahswuaj", Description = "adnijkadn" },
                new employee { Id = 2, Name = "baubhjd", Description = "bhasjdad" });
            modelBuilder.Entity<department>()
                .HasData(new department { DId = 1, Dname = "hyderabad", Description = "very good place" },
                new department { DId = 2, Dname = "bangalore", Description = "very nice plklac e" });

            modelBuilder.Entity<both>()
                .HasData(new both { id = 1, Did = 2},
                new both {  id = 2, Did = 1});
        }
    }
}

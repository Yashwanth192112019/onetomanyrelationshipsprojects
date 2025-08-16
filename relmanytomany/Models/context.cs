using Microsoft.EntityFrameworkCore;

namespace relmanytomany.Models
{
    public class context :DbContext
    {
        public context() { }

        public context(DbContextOptions<context> options) : base(options) { }

        public DbSet<fly> birds { get; set; }
        public DbSet<cantfly> cantflybirds { get; set; }
        
        public DbSet<both> both {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("data source = YASH_MALLADI; database = parject; integrated security = true; trustservercertificate = true;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<both>()
                .HasKey(ba => new { ba.bid, ba.cId });

            modelBuilder.Entity<both>()
                .HasOne(a => a.fly)
                .WithMany(a => a.both)
                .HasForeignKey(ba => ba.bid);
            modelBuilder.Entity<both>()
                .HasOne(a => a.cantfly)
                .WithMany(a => a.both)
                .HasForeignKey(a => a.cId);

            modelBuilder.Entity<fly>()
                .HasData(new fly() { bId = 1, cname = "yashwanth", age = 4 },
                new fly() { bId = 2, cname = "jnadk", age = 8 });
            modelBuilder.Entity<cantfly>()
                .HasData(new cantfly() { cId = 1, bname = "b SJK", age = 22 },
                new cantfly() { cId = 2, bname = "yashoo", age = 34 });

            modelBuilder.Entity<both>()
                .HasData(new both { bid = 1, cId = 2, },
                new both { bid = 2, cId = 1 });
        }
    }
}

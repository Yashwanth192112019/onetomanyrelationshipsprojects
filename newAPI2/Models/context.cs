using Microsoft.EntityFrameworkCore;

namespace newAPI2.Models
{
    public class context : DbContext
    {   
        public context() { }

        public context(DbContextOptions<context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("data source = YASH_MALLADI; database = anibird; integrated security = true; trustservercertificate = true;");
            
        public DbSet<Bird> birds { get; set; }

        public DbSet<Animal> animals { get; set; }

        //seeding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasData(new Animal() { AnimalId = 1, SpeciesName = "bald eagle", Description = "flies high and became bald", Habitat = "mountains" },
                new Animal() { AnimalId = 2, SpeciesName = "bald penguin", Description = "walks high and became bald", Habitat = "North pole" });
            modelBuilder.Entity<Bird>()
                .HasData(new Bird() { AnimalId = 2, Age = 22, BirdId = 1, BirdName = "barad", Color = "black and white" },
                new Bird() { AnimalId = 1, Age = 25, BirdId = 2, BirdName = "bread", Color = "blue and green" });
        }
    }
}

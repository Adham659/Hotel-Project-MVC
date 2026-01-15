using Microsoft.EntityFrameworkCore;

namespace DeluxeHotelMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }



        public DbSet<User> Users { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
       
        public DbSet<Service> Services { get; set; }
        
        
        public DbSet<Feature> Features { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         

            // RoomFeature relation
            modelBuilder.Entity<RoomFeature>()
                .HasOne(r => r.Room)
                .WithMany(r => r.RoomFeatures)
                .HasForeignKey(r => r.RoomID);

            modelBuilder.Entity<RoomFeature>()
                .HasOne(f => f.Feature)
                .WithMany()
                .HasForeignKey(f => f.FeatureID);
        }

    }
}

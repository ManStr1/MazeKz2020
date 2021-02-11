using Microsoft.EntityFrameworkCore;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff
{
    public class WebMazeContext : DbContext
    {
        public DbSet<CitizenUser> CitizenUser { get; set; }

        public DbSet<Adress> Adress { get; set; }

        public DbSet<Policeman> Policemen { get; set; }

        public DbSet<Violation> Violations { get; set; }
        
        public DbSet<ViolationType> TypesOfViolation { get; set; }

        public DbSet<HealthDepartment> HealthDepartment { get; set; }

        public DbSet<Bus> Bus { get; set; }

        public DbSet<BusStop> BusStop { get; set; }

        public DbSet<BusRoute> BusRoute { get; set; }

        public DbSet<UserTask> UserTasks { get; set; }

        public DbSet<RestPlace> RestPlace { get; set; }

        public DbSet<RestCategory> RestCategory { get; set; }

        public DbSet<RestPhoto> RestPhoto { get; set; }

        public DbSet<RestComment> RestComment { get; set; }

        public DbSet<RestEvent> RestEvent { get; set; }

        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitizenUser>()
                .HasMany(citizen => citizen.Adresses)
                .WithOne(adress => adress.Owner);

            modelBuilder.Entity<RestPlace>()
                .HasMany(place => place.RestPhotos)
                .WithOne(photos => photos.Place);

            modelBuilder.Entity<RestPlace>()
                .HasMany(place => place.RestComments)
                .WithOne(comments => comments.Place);

            modelBuilder.Entity<RestPlace>()
                .HasMany(place => place.RestEvents)
                .WithOne(events => events.Place);

            base.OnModelCreating(modelBuilder);
        }
    }
}

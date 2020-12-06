namespace Catman.Education.Persistence
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Interfaces;
    using Microsoft.EntityFrameworkCore;

    internal class ApplicationStore : DbContext, IApplicationStore
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Group> Groups { get; set; }

        public ApplicationStore(DbContextOptions<ApplicationStore> options)
            : base(options)
        {
        }
        
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationStore).Assembly);
        }
    }
}

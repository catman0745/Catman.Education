namespace Catman.Education.Application.Interfaces
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationStore
    {
        DbSet<User> Users { get; }

        Task SaveChangesAsync();
    }
}

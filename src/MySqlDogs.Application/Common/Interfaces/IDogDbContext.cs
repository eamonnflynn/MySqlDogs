using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Common.Interfaces
{
    public interface IDogDbContext
    {
        DbSet<Dog> Dogs { get; set; }
        DbSet<Breed> Breeds { get; set; }

        DbSet<DogGroup> Groups { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
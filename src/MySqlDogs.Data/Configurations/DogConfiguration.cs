using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlDogs.Core;

namespace MySqlDogs.Data.Configurations
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            // Method intentionally left empty.
        }
    }
}

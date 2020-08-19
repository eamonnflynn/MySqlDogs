using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlDogs.Core;

namespace MySqlDogs.Data.Configurations
{
    public class DogGroupConfiguration : IEntityTypeConfiguration<DogGroup>
    {
        public void Configure(EntityTypeBuilder<DogGroup> builder)
        {
            builder.Property(e => e.DogGroupId).HasConversion<int>();
            builder.HasData(

                Enum.GetValues(typeof(DogGroupId))
                    .Cast<DogGroupId>().Select(e => new DogGroup()
                        {
                            DogGroupId = e,
                            Name = e.ToString()
                        })
            );
        }
    }
}

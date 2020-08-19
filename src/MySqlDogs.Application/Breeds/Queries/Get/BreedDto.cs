using AutoMapper;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Queries.Get
{
    public class BreedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DogGroupId GroupId { get; set; }
        public virtual DogGroup Group { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Breed, BreedDto>();
        }
    }
}

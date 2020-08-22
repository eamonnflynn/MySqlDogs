using AutoMapper;
using MySqlDogs.Application.Common.Mappings;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Dogs.Queries.Get
{
    public class DogDto :IMapFrom<Dog>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BreedId { get; set; }
        public string Breed
        {
            get;
            set;
        }

        public string Colour { get; set; }

        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dog, DogDto>().ForMember(b => b.Breed, opt => opt.MapFrom(d => d.Breed.Name));
        }
    }
}
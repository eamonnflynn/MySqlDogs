using AutoMapper;
using MySqlDogs.Application.Common.Mappings;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Breeds.Queries.Get
{
    public class BreedDto :IMapFrom<Breed>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DogGroupId GroupId { get; set; }
        public string DogGroup { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Breed, BreedDto>()
                
                .ForMember(b=>b.DogGroup, opt=>opt.MapFrom(g=>g.Group.Name));
        }
    }
}

using AutoMapper;
using MySqlDogs.Application.Common.Mappings;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.DogGroups.Queries.Get
{
    public class DogGroupDto :IMapFrom<DogGroup>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<DogGroup, DogGroupDto>().ForMember(g=>g.Id, opt=>opt.MapFrom(s=>(int) s.DogGroupId));
        }
    }
}
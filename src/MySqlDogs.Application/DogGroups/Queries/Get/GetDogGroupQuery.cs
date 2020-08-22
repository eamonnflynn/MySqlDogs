using MediatR;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.DogGroups.Queries.Get
{
   
        public class GetDogGroupQuery : IRequest<DogGroupDto>
        {
            public DogGroupId Id { get; set; }
        }
}

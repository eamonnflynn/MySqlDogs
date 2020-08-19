using MediatR;
using MySqlDogs.Core;

namespace MySqlDogs.Application.DogGroups.Queries.Get
{
   
        public class GetDogGroupQuery : IRequest<DogGroupDto>
        {
            public DogGroupId Id { get; set; }
        }
}

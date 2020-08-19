using MediatR;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Commands.Create
{
    public class CreateBreedCommand : IRequest<int>
    {
        public string Name { get; set; }

        public DogGroupId GroupId { get; set; }
       
    }
}

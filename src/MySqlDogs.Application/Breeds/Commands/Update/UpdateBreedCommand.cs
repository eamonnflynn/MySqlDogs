using MediatR;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Breeds.Commands.Update
{
    public class UpdateBreedCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DogGroupId GroupId { get; set; }
    }
}

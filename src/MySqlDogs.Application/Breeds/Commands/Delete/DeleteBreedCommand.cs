using MediatR;

namespace MySqlDogs.Application.Breeds.Commands.Delete
{
    public class DeleteBreedCommand : IRequest
    {
        public int Id { get; set; }
    }
}

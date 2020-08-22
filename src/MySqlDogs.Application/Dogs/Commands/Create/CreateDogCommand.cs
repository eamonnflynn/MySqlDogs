using MediatR;

namespace MySqlDogs.Application.Dogs.Commands.Create
{
    public class CreateDogCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public string Colour { get; set; }
    }
}

using MediatR;

namespace MySqlDogs.Application.Dogs.Commands.Update
{
    public class UpdateDogCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public string Colour { get; set; }
    }
}

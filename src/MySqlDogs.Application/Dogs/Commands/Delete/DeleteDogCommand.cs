using MediatR;

namespace MySqlDogs.Application.Dogs.Commands.Delete
{
   

    public class DeleteDogCommand : IRequest
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace MySqlDogs.Application.Dogs.Queries.Get
{
    public class GetDogQuery : IRequest<DogDto>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace MySqlDogs.Application.Breeds.Queries.Get
{
    public class GetBreedQuery : IRequest<BreedDto>
    {
        public int Id { get; set; }
    }
}

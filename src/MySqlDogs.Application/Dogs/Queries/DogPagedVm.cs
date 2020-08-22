using MySqlDogs.Application.Dogs.Queries.Get;

namespace MySqlDogs.Application.Dogs.Queries
{
    public class DogPagedVm
    {
        public PagedResult<DogDto> List { get; set; }
    }
}
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Queries.GetPaged
{
    public class BreedPagedVm
    {
        public PagedResult<Breed> List { get; set; }
    }
}
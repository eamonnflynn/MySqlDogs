using MySqlDogs.Application.Breeds.Queries.Get;


namespace MySqlDogs.Application.Breeds.Queries
{
    public class BreedPagedVm
    {
        public PagedResult<BreedDto> List { get; set; }
    }
}
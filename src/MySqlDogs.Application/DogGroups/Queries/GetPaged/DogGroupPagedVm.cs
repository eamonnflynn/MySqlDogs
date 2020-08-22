using MySqlDogs.Core.Entites;


namespace MySqlDogs.Application.DogGroups.Queries.GetPaged
{
    public class DogGroupPagedVm
    {
        public PagedResult<DogGroup> List { get; set; }
    }
}
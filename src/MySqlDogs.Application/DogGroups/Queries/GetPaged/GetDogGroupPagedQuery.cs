using MediatR;

namespace MySqlDogs.Application.DogGroups.Queries.GetPaged
{
    public class GetDogGroupPagedQuery : IRequest<DogGroupPagedVm>
    {
        public GetDogGroupPagedQuery(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

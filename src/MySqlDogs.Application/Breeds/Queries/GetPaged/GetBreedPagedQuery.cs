using MediatR;

namespace MySqlDogs.Application.Breeds.Queries.GetPaged
{
 

    public class GetBreedPagedQuery : IRequest<BreedPagedVm>
    {
        public GetBreedPagedQuery(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

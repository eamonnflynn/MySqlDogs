using MediatR;

namespace MySqlDogs.Application.Dogs.Queries.GetPaged
{
  

    public class GetDogPagedQuery : IRequest<DogPagedVm>
    {
        public GetDogPagedQuery(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

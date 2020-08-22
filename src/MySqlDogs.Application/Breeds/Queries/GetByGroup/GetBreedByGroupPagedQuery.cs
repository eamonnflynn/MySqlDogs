using MediatR;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Breeds.Queries.GetByGroup
{
    public class GetBreedByGroupPagedQuery : IRequest<BreedPagedVm>
    {
        public GetBreedByGroupPagedQuery(DogGroupId groupId, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.GroupId = groupId;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public DogGroupId GroupId { get; set; }
    }
}

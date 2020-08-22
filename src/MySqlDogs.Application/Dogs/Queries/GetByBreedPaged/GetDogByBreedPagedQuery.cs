using MediatR;


namespace MySqlDogs.Application.Dogs.Queries.GetByBreedPaged
{
    public class GetDogByBreedPagedQuery : IRequest<DogPagedVm>
    {
        public GetDogByBreedPagedQuery(int breedId, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.BreedId = breedId;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int BreedId { get; set; }
    }
}

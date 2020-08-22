using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Application.Dogs.Queries.Get;

namespace MySqlDogs.Application.Dogs.Queries.GetByBreedPaged
{
    public  class GetDogByBreedPagedQueryHandler: IRequestHandler<GetDogByBreedPagedQuery, DogPagedVm>
    {
        private readonly IDogDbContext _context;
        private readonly IMapper _mapper;

        public GetDogByBreedPagedQueryHandler(IDogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<DogPagedVm> Handle(GetDogByBreedPagedQuery request, CancellationToken cancellationToken)
        {
            return new DogPagedVm
            {
                List = await _context.Dogs.Where(d=>d.BreedId == request.BreedId)
                    .ProjectTo<DogDto>(_mapper.ConfigurationProvider)
                    .GetPagedAsync(request.PageIndex, request.PageSize)
            };
        }
    }
}

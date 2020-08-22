using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MySqlDogs.Application.Breeds.Queries.Get;
using MySqlDogs.Application.Common.Interfaces;

namespace MySqlDogs.Application.Breeds.Queries.GetByGroup
{
    public class GetBreedByGroupPagedQueryHandler : IRequestHandler<GetBreedByGroupPagedQuery, BreedPagedVm>
    {

        private readonly IDogDbContext _context;
        private readonly IMapper _mapper;

        public GetBreedByGroupPagedQueryHandler(IDogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BreedPagedVm> Handle(GetBreedByGroupPagedQuery request, CancellationToken cancellationToken)
        {
            return new BreedPagedVm
            {
                List = await _context.Breeds.Where(x=>x.GroupId == request.GroupId)
                    .ProjectTo<BreedDto>(_mapper.ConfigurationProvider)
                    .GetPagedAsync(request.PageIndex, request.PageSize)
            };
        }
    }
}

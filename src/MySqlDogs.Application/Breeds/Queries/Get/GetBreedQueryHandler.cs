using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySqlDogs.Application.Common.Interfaces;

namespace MySqlDogs.Application.Breeds.Queries.Get
{
    public class GetBreedQueryHandler : IRequestHandler<GetBreedQuery, BreedDto>
    {
        private readonly IDogDbContext _context;
        private readonly IMapper _mapper;

        public GetBreedQueryHandler(IDogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BreedDto> Handle(GetBreedQuery request, CancellationToken cancellationToken)
        {
            return await _context.Breeds.Where(b => b.Id == request.Id)
                .ProjectTo<BreedDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
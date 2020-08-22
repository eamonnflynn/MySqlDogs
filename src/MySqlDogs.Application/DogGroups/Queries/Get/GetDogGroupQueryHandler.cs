using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySqlDogs.Application.Common.Interfaces;

namespace MySqlDogs.Application.DogGroups.Queries.Get
{
    public class GetDogGroupQueryHandler : IRequestHandler<GetDogGroupQuery, DogGroupDto>
    {
        private readonly IDogDbContext _context;
        private readonly IMapper _mapper;

        public GetDogGroupQueryHandler(IDogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DogGroupDto> Handle(GetDogGroupQuery request, CancellationToken cancellationToken)
        {
            return await _context.Groups.Where(b => b.DogGroupId == request.Id)
                .ProjectTo<DogGroupDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
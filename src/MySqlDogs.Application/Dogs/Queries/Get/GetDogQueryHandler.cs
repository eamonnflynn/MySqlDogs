using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySqlDogs.Application.Common.Interfaces;

namespace MySqlDogs.Application.Dogs.Queries.Get
{
    public class GetDogQueryHandler : IRequestHandler<GetDogQuery, DogDto>
    {
        
        private readonly IDogDbContext _context;
        private readonly IMapper _mapper;

        public GetDogQueryHandler(IDogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DogDto> Handle(GetDogQuery request, CancellationToken cancellationToken)
        {
            return await _context.Dogs.Where(d=>d.Id == request.Id)
                .ProjectTo<DogDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

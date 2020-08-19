using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Interfaces;

namespace MySqlDogs.Application.DogGroups.Queries.GetPaged
{
    public class GetDogGroupPagedQueryHandler : IRequestHandler<GetDogGroupPagedQuery, DogGroupPagedVm>
    {
        private readonly IDogDbContext _context;

        public GetDogGroupPagedQueryHandler(IDogDbContext context)
        {
            _context = context;
        }
        public async Task<DogGroupPagedVm> Handle(GetDogGroupPagedQuery request, CancellationToken cancellationToken)
        {
            
            return new DogGroupPagedVm
            {
                List = await _context.Groups.GetPagedAsync(request.PageIndex, request.PageSize)
            };
        }
    }
}

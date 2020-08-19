using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Commands.Create
{
    public class CreateBreedCommandHandler : IRequestHandler<CreateBreedCommand, int>
    {
        private readonly IDogDbContext _context;

        public CreateBreedCommandHandler(IDogDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBreedCommand request, CancellationToken cancellationToken)
        {
            var entity = new Breed
            {
                Name = request.Name,
                GroupId = request.GroupId
            };

            await _context.Breeds.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
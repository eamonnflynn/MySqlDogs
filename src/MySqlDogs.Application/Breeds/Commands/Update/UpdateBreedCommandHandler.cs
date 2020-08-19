using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Exceptions;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Commands.Update
{
    public class UpdateBreedCommandHandler : IRequestHandler<UpdateBreedCommand>
    {
        private readonly IDogDbContext _context;
        public UpdateBreedCommandHandler(IDogDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateBreedCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Breeds.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Breed), request.Id);
            }

            entity.Name = request.Name;
            entity.GroupId = request.GroupId;
        

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

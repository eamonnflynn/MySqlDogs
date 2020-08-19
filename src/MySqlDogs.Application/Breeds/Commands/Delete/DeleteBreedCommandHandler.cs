using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Exceptions;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core;

namespace MySqlDogs.Application.Breeds.Commands.Delete
{
    public class DeleteBreedCommandHandler : IRequestHandler<DeleteBreedCommand>
    {
        private readonly IDogDbContext _context;
        public DeleteBreedCommandHandler(IDogDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBreedCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Breeds.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Breed), request.Id);
            }

            _context.Breeds.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

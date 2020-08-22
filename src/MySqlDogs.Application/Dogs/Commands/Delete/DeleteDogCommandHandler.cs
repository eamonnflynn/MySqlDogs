using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Exceptions;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Dogs.Commands.Delete
{
    
    public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand>
    {
        private readonly IDogDbContext _context;
        public DeleteDogCommandHandler(IDogDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Dogs.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Dog), request.Id);
            }

            _context.Dogs.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

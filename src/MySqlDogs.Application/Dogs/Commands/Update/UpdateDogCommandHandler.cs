using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Exceptions;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Dogs.Commands.Update
{
   

    public class UpdateDogCommandHandler : IRequestHandler<UpdateDogCommand>
    {
        private readonly IDogDbContext _context;
        public UpdateDogCommandHandler(IDogDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateDogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Dogs.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Breed), request.Id);
            }

            entity.Name = request.Name;
            entity.Age = request.Age;
            entity.BreedId = request.BreedId;
            entity.Colour = request.Colour;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

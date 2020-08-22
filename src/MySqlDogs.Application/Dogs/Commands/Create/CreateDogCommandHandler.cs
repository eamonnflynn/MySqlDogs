using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MySqlDogs.Application.Common.Interfaces;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.Application.Dogs.Commands.Create
{
    

    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
    {
        private readonly IDogDbContext _context;

        public CreateDogCommandHandler(IDogDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var entity = new Dog
            {
                Name = request.Name,
                Age = request.Age,
                BreedId = request.BreedId,
                Colour = request.Colour
                
            };

            await _context.Dogs.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

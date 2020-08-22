using FluentValidation;

namespace MySqlDogs.Application.Dogs.Commands.Create
{
    public class CreateDogCommandValidator :AbstractValidator<CreateDogCommand>
    {
        public CreateDogCommandValidator()
        {
        }

        
    }
}

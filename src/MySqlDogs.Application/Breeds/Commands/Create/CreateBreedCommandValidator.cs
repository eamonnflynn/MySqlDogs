using FluentValidation;

namespace MySqlDogs.Application.Breeds.Commands.Create
{
    public class CreateBreedCommandValidator: AbstractValidator<CreateBreedCommand>
    {
        public CreateBreedCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required").MaximumLength(300)
                .WithMessage("Breed Name cannot exceed 300 characters");
        }
    }
}

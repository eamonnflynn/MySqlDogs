using System.Threading.Tasks;
using FluentAssertions;
using MySqlDogs.Application.Common.Exceptions;
using MySqlDogs.Application.Dogs.Commands.Create;
using MySqlDogs.Core.Entites;
using NUnit.Framework;

namespace MySqlDogs.Application.IntegrationTests.Dogs.Commands
{
    using static Testing;

    public class CreateDogTests :TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateDogCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }


        [Test]
        public async Task ShouldCreateTodoItem()
  
        {


            var command = new CreateDogCommand()
            {
                Age = 2,
               BreedId = 1,
               Colour = "Browm",
               Name ="Cocoa"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Dog>(itemId);

            item.Should().NotBeNull();
            item.Id.Should().BeGreaterThan(0);
            item.Age.Should().Be(command.Age);
            item.BreedId.Should().Be(command.BreedId);
            item.Colour.Should().Be(command.Colour);
            item.Name.Should().Be(command.Name);

        }
    }
}

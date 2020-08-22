using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDogs.Application.Dogs.Commands.Create;
using MySqlDogs.Application.Dogs.Commands.Delete;
using MySqlDogs.Application.Dogs.Commands.Update;
using MySqlDogs.Application.Dogs.Queries;
using MySqlDogs.Application.Dogs.Queries.Get;
using MySqlDogs.Application.Dogs.Queries.GetByBreedPaged;
using MySqlDogs.Application.Dogs.Queries.GetPaged;

namespace MySqlDogs.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DogController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<DogPagedVm>> GetPaged(int pageindex, int pageSize)
        {
            return await Mediator.Send(new GetDogPagedQuery(pageindex, pageSize));
        }

        [HttpGet("{breedId}")]
        public async Task<ActionResult<DogPagedVm>> GetByBreedPaged(int breedId, int pageindex, int pageSize)
        {
            return await Mediator.Send(new GetDogByBreedPagedQuery(breedId, pageindex, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogDto>> Get(int id)
        {
            var breedDto = await Mediator.Send(new GetDogQuery { Id = id });

            return breedDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDogCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateDogCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDogCommand { Id = id });

            return NoContent();
        }
    }
}

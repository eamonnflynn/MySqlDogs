using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDogs.Application.Breeds.Commands.Create;
using MySqlDogs.Application.Breeds.Commands.Delete;
using MySqlDogs.Application.Breeds.Commands.Update;
using MySqlDogs.Application.Breeds.Queries;
using MySqlDogs.Application.Breeds.Queries.Get;
using MySqlDogs.Application.Breeds.Queries.GetByGroup;
using MySqlDogs.Application.Breeds.Queries.GetPaged;
using MySqlDogs.Core.Entites;

namespace MySqlDogs.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BreedController : ApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<BreedPagedVm>> GetPaged(int pageindex, int pageSize)
        {
            return await Mediator.Send(new GetBreedPagedQuery(pageindex, pageSize));
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<BreedPagedVm>> GetByGroupPaged(DogGroupId groupId, int pageindex, int pageSize)
        {
            return await Mediator.Send(new GetBreedByGroupPagedQuery(groupId,pageindex, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BreedDto>> Get(int id)
        {
            var breedDto = await Mediator.Send(new GetBreedQuery { Id = id });

            return breedDto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBreedCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBreedCommand command)
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
            await Mediator.Send(new DeleteBreedCommand { Id = id });

            return NoContent();
        }
    }
}

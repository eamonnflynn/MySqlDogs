using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDogs.Application.DogGroups.Queries.Get;
using MySqlDogs.Application.DogGroups.Queries.GetPaged;
using MySqlDogs.Core;

namespace MySqlDogs.WebApi.Controllers
{
  
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DogGroupController : ApiController
    {
       

        [HttpGet]
        public async Task<ActionResult<DogGroupPagedVm>> GetPaged(int pageindex, int pageSize)
        {
            return await Mediator.Send(new GetDogGroupPagedQuery(pageindex, pageSize));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DogGroupDto>> Get(DogGroupId id)
        {
            var dto = await Mediator.Send(new GetDogGroupQuery { Id = id });

            return dto;
        }
    }

    
}

using System.Threading.Tasks;
using GraphQLDemo.Application.UseCases.DesignPattern;
using GraphQLDemo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemo.WebApi.UseCases
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignPatternController : ControllerBase
    {
        private readonly IDesignPaternUseCase designPaternUseCase;

        public DesignPatternController(IDesignPaternUseCase designPaternUseCase)
        {
            this.designPaternUseCase = designPaternUseCase;
        }

        [HttpPost]
        [Route("DesignPatterns")]
        public async Task<IActionResult> GetProfiles([FromBody] GraphQLQuery query)
        {
            var result = await designPaternUseCase.Execute(query.Input);
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Params;
using Services.Commands.BlogLikesCommands;
using Services.Queries.BlogLikesQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BlogLikesParams param)
        {
            var entity = await _mediator.Send(new GetBlogLikesListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetBlogLikesByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BlogLikesForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertBlogLikesCommand(creationDTO));
            var model = await _mediator.Send(new GetBlogLikesByIdQuery(entity.Id.Value));
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BlogLikesForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateBlogLikesCommand(updateDTO));
            var model = await _mediator.Send(new GetBlogLikesByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteBlogLikesCommand(id));
            return NoContent();
        }
    }
}

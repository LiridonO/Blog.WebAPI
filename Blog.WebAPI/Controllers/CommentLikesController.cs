using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Params;
using Services.Commands.CommentLikesCommands;
using Services.Queries.CommentLikesQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CommentLikesParams param)
        {
            var entity = await _mediator.Send(new GetCommentLikesListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetCommentLikesByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentLikesForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertCommentLikesCommand(creationDTO));
            var model = await _mediator.Send(new GetCommentLikesByIdQuery(entity.Id.Value));
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CommentLikesForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateCommentLikesCommand(updateDTO));
            var model = await _mediator.Send(new GetCommentLikesByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCommentLikesCommand(id));
            return NoContent();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using Services.Commands.BlogsCommands;
using Services.Commands.CommentsCommands;
using Services.Queries.CommentsQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CommentsParams param)
        {
            var entity = await _mediator.Send(new GetCommentsListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetCommentsByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        [Authorize]
        public async Task<DefaultResponse<Comments>> Post(CommentsForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertCommentsCommand(creationDTO));
            return entity;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(CommentsForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateCommentsCommand(updateDTO));
            var model = await _mediator.Send(new GetCommentsByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DefaultResponse<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBlogsCommand(id));
            return result;
        }
    }
}

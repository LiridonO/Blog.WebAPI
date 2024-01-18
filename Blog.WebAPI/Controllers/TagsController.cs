using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using Services.Commands.TagsCommands;
using Services.Queries.TagsQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TagsParams param)
        {
            var entity = await _mediator.Send(new GetTagsListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetTagsByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        [Authorize]
        public async Task<DefaultResponse<Tags>> Post(TagsForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertTagsCommand(creationDTO));
            return entity;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(TagsForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateTagsCommand(updateDTO));
            var model = await _mediator.Send(new GetTagsByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DefaultResponse<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteTagsCommand(id));
            return result;
        }
    }
}

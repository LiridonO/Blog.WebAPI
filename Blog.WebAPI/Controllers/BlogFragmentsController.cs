using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using Services.Commands.BlogFragmentsCommands;
using Services.Queries.BlogFragmentsQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogFragmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogFragmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BlogFragmentsParams param)
        {
            var entity = await _mediator.Send(new GetBlogFragmentsListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetBlogFragmentsByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        [Authorize]
        public async Task<DefaultResponse<BlogFragments>> Post(BlogFragmentsForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertBlogFragmentsCommand(creationDTO));
            return entity;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(BlogFragmentsForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateBlogFragmentsCommand(updateDTO));
            var model = await _mediator.Send(new GetBlogFragmentsByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DefaultResponse<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBlogFragmentsCommand(id));
            return result;
        }

        //[HttpPut("BlogFragmentsRenditja")]
        //public async Task<IActionResult> BlogFragmentsRenditjaUpdate(List<BlogFragmentsRenditjaForUpdateDTO> updateDTO)
        //{
        //    await _mediator.Send(new UpdateBlogFragmentsRenditjaCommand(updateDTO));
        //    return Ok();
        //}
    }
}

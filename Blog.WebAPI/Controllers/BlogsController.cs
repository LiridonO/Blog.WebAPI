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
using Services.Queries.BlogsQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BlogsParams param)
        {
            var entity = await _mediator.Send(new GetBlogsListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetBlogsByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        [Authorize]
        public async Task<DefaultResponse<Blogs>> Post(BlogsForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertBlogsCommand(creationDTO));
            return entity;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(BlogsForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateBlogsCommand(updateDTO));
            var model = await _mediator.Send(new GetBlogsByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DefaultResponse<bool>> Delete(Guid id)
        {
            var results = await _mediator.Send(new DeleteBlogsCommand(id));
            return results;
        }

        //[HttpPut("BlogsRenditja")]
        //public async Task<IActionResult> BlogsRenditjaUpdate(List<BlogsRenditjaForUpdateDTO> updateDTO)
        //{
        //    await _mediator.Send(new UpdateBlogsRenditjaCommand(updateDTO));
        //    return Ok();
        //}
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using Services.Commands.DocumentsCommands;
using Services.Queries.DocumentsQuery;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DocumentsParams param)
        {
            var entity = await _mediator.Send(new GetDocumentsListQuery(param));
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _mediator.Send(new GetDocumentsByIdQuery(id));
            return Ok(entity);
        }

        [HttpPost]
        [Authorize]
        public async Task<DefaultResponse<Documents>> Post(DocumentsForCreationDTO creationDTO)
        {
            var entity = await _mediator.Send(new InsertDocumentsCommand(creationDTO));
            return entity;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(DocumentsForUpdateDTO updateDTO)
        {
            await _mediator.Send(new UpdateDocumentsCommand(updateDTO));
            var model = await _mediator.Send(new GetDocumentsByIdQuery(updateDTO.Id));
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DefaultResponse<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteDocumentsCommand(id));
            return result;
        }
    }
}

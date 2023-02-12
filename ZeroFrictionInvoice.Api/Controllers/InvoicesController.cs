using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZeroFrictionInvoice.Application.Commands;
using ZeroFrictionInvoice.Application.Queries;

namespace ZeroFrictionInvoice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllInvoices")]
    public async Task<IActionResult> GetAllInvoices()
    {
        var query = new GetAllInvoicesQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetInvoiceById")]
    public async Task<IActionResult> GetInvoiceById([FromRoute] string id)
    {
        var query = new GetInvoiceByIdQuery();
        query.Id = id;

        var result = await _mediator.Send(query);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost(Name = "CreateInvoice")]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
    {
        var result = await _mediator.Send(command);

        return result != null ? CreatedAtAction("GetInvoiceById", new { Id = result.Invoice.Id }, result.Invoice) : BadRequest();
    }

    [HttpPut("{id}", Name = "UpdateInvoice")]
    public async Task<IActionResult> UpdateInvoice([FromRoute] string id, [FromBody] UpdateInvoiceCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        return result != null ? result.HasValidationErrors ? BadRequest() : Ok() : NotFound();
    }
}
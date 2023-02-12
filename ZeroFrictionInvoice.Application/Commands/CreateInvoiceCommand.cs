using MediatR;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Application.Responses;

namespace ZeroFrictionInvoice.Application.Commands;

public class CreateInvoiceCommand : IRequest<InvoiceCreatedResponse>
{
    public DateTime? Date { get; set; }

    public string Description { get; set; }

    public List<InvoiceLineModel> InvoiceLines { get; set; } = new();
}

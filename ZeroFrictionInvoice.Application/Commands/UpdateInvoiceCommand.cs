using MediatR;
using System.Text.Json.Serialization;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Application.Responses;

namespace ZeroFrictionInvoice.Application.Commands;

public class UpdateInvoiceCommand : IRequest<InvoiceUpdatedResponse>
{
    [JsonIgnore]
    public string Id { get; set; }

    public DateTime? Date { get; set; }

    public string Description { get; set; }

    public List<InvoiceLineModel> InvoiceLines { get; set; } = new();
}

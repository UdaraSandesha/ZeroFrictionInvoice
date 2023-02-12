using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ZeroFrictionInvoice.Application.Models;

namespace ZeroFrictionInvoice.Application.Queries;

public class GetInvoiceByIdQuery : IRequest<InvoiceModel>
{
    [BindNever]
    public string Id { get; set; }
}

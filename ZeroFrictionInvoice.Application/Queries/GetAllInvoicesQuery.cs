using MediatR;
using ZeroFrictionInvoice.Application.Models;

namespace ZeroFrictionInvoice.Application.Queries;

public class GetAllInvoicesQuery : IRequest<IEnumerable<InvoiceModel>>
{
}

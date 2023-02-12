using AutoMapper;
using MediatR;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Application.Queries;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Application.Handlers;

public class GetAllInvoicesHandler : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceModel>>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;

    public GetAllInvoicesHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceModel>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var result = await _invoiceRepository.GetAllInvoicesAsync();

        return _mapper.Map<List<InvoiceModel>>(result);
    }
}

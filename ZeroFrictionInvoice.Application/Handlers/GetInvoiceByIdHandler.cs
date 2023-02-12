using AutoMapper;
using MediatR;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Application.Queries;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Application.Handlers;

public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceModel>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;

    public GetInvoiceByIdHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public async Task<InvoiceModel> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _invoiceRepository.GetInvoiceByIdAsync(request.Id);

        return _mapper.Map<InvoiceModel>(result);
    }
}

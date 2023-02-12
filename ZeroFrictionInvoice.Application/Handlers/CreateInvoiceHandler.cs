using AutoMapper;
using MediatR;
using ZeroFrictionInvoice.Application.Commands;
using ZeroFrictionInvoice.Application.Responses;
using ZeroFrictionInvoice.Domain.Entities.Invoices;
using ZeroFrictionInvoice.Domain.Repositories;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Application.Handlers;

public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, InvoiceCreatedResponse?>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateInvoiceHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<InvoiceCreatedResponse?> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (!request.InvoiceLines.Any() || request.Description == null || request.Date is null)
        {
            return new InvoiceCreatedResponse { HasValidationErrors = true };
        }

        var invoice = _mapper.Map<Invoice>(request);

        CreateInvoiceLines(invoice);

        _invoiceRepository.Add(invoice);
        await _unitOfWork.SaveChangesAsync();

        return new InvoiceCreatedResponse { Invoice = invoice };
    }

    private void CreateInvoiceLines(Invoice invoice)
    {
        foreach (var invoiceLine in invoice.InvoiceLines)
        {
            invoiceLine.LineAmount = invoiceLine.Quantity * invoiceLine.UnitPrice;
            invoice.TotalAmount += invoiceLine.LineAmount;
        }
    }
}
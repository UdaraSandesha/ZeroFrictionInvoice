using AutoMapper;
using MediatR;
using ZeroFrictionInvoice.Application.Commands;
using ZeroFrictionInvoice.Application.Responses;
using ZeroFrictionInvoice.Domain.Entities.Invoices;
using ZeroFrictionInvoice.Domain.Repositories;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Application.Handlers;

public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceUpdatedResponse?>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateInvoiceHandler(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<InvoiceUpdatedResponse?> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (!request.InvoiceLines.Any() || request.Description == null || request.Date is null)
        {
            return new InvoiceUpdatedResponse { HasValidationErrors = true };
        }

        var invoice = await _invoiceRepository.GetInvoiceByIdAsync(request.Id);
        if (invoice is null)
        {
            return null;
        }

        invoice.Date = request.Date.Value;
        invoice.Description = request.Description;

        UpdateInvoiceLines(request, invoice);

        await _unitOfWork.SaveChangesAsync();

        return new InvoiceUpdatedResponse();
    }

    private void UpdateInvoiceLines(UpdateInvoiceCommand request, Invoice invoice)
    {
        var invoiceLines = _mapper.Map<List<InvoiceLine>>(request.InvoiceLines);

        foreach (var invoiceLine in invoiceLines)
        {
            invoiceLine.LineAmount = invoiceLine.Quantity * invoiceLine.UnitPrice;
            invoice.TotalAmount += invoiceLine.LineAmount;
        }

        invoice.InvoiceLines = invoiceLines;
    }
}
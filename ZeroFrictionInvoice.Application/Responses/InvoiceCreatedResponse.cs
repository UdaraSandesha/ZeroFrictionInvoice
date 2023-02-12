using ZeroFrictionInvoice.Domain.Entities.Invoices;

namespace ZeroFrictionInvoice.Application.Responses;

public class InvoiceCreatedResponse : BaseResponse
{
    public Invoice Invoice { get; set; }

    public bool HasValidationErrors { get; set; }
}

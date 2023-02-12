namespace ZeroFrictionInvoice.Application.Responses;

public class InvoiceUpdatedResponse : BaseResponse
{
    public bool HasValidationErrors { get; set; }
}

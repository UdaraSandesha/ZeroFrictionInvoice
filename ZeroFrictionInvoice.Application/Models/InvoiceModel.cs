namespace ZeroFrictionInvoice.Application.Models;

public class InvoiceModel
{
    public string Id { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; }

    public double TotalAmount { get; set; }

    public List<InvoiceLineModel> InvoiceLines { get; set; } = new();
}

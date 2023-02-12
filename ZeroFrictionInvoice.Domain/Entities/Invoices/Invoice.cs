namespace ZeroFrictionInvoice.Domain.Entities.Invoices;

public class Invoice : IAggregateRoot
{
    public string Id { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; }

    public double TotalAmount { get; set; }

    public List<InvoiceLine> InvoiceLines { get; set; } = new();
}
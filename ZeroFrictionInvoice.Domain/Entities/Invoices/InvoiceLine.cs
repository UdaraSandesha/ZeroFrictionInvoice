namespace ZeroFrictionInvoice.Domain.Entities.Invoices;

public class InvoiceLine
{
    public string Id { get; set; }

    public string Item { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double LineAmount { get; set; }
}

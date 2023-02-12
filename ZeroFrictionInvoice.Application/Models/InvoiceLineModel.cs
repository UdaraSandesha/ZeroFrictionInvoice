namespace ZeroFrictionInvoice.Application.Models;

public class InvoiceLineModel
{
    public string Item { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }
}
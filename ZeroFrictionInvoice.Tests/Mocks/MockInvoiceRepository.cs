using Moq;
using ZeroFrictionInvoice.Domain.Entities.Invoices;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;

namespace ZeroFrictionInvoice.Tests.Mocks;

public static class MockInvoiceRepository
{
    public static Mock<IInvoiceRepository> GetInvoiceRepository()
    {
        var invoices = new List<Invoice>
        {
            new Invoice
            {
                Id = "350cbe01-1f06-427f-8d3c-1d28f2f593ff",
                Date = DateTime.UtcNow,
                Description= "Description1",
                TotalAmount = 100.25
            },
            new Invoice
            {
                Id = "b211ef70-3588-4273-ab9e-e327c6a716e0",
                Date = DateTime.UtcNow.AddDays(1),
                Description= "Description2",
                TotalAmount = 100.25
            },
        };

        var mockRepo = new Mock<IInvoiceRepository>();

        mockRepo.Setup(i => i.GetAllInvoicesAsync()).ReturnsAsync(invoices);

        mockRepo.Setup(i => i.Add(It.IsAny<Invoice>()))
            .Callback((Invoice invoice) => invoices.Add(invoice));

        return mockRepo;
    }
}

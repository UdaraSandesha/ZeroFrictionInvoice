using AutoMapper;
using Moq;
using Shouldly;
using ZeroFrictionInvoice.Application.Commands;
using ZeroFrictionInvoice.Application.Handlers;
using ZeroFrictionInvoice.Application.Mappers;
using ZeroFrictionInvoice.Domain.Repositories;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;
using ZeroFrictionInvoice.Tests.Mocks;

namespace ZeroFrictionInvoice.Tests;

public class CreateInvoiceHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IInvoiceRepository> _mockRepo;

    public CreateInvoiceHandlerTests()
    {
        _mockRepo = MockInvoiceRepository.GetInvoiceRepository();

        var mapperProfile = new MapperConfiguration(i => i.AddProfile<InvoiceMapperProfile>());

        _mapper = mapperProfile.CreateMapper();
    }

    [Fact]
    public async Task CreateInvoiceAddsANewRecord()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CreateInvoiceHandler(_mockRepo.Object, mockUnitOfWork.Object, _mapper);

        var result = await handler.Handle(new CreateInvoiceCommand() { Date = DateTime.UtcNow, Description = "Description" }, CancellationToken.None);

        var invoices = await _mockRepo.Object.GetAllInvoicesAsync();

        invoices.Count().ShouldBe(2);
    }
}

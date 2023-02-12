using AutoMapper;
using Moq;
using Shouldly;
using ZeroFrictionInvoice.Application.Handlers;
using ZeroFrictionInvoice.Application.Mappers;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Application.Queries;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;
using ZeroFrictionInvoice.Tests.Mocks;

namespace ZeroFrictionInvoice.Tests;

public class GetAllInvoicesHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IInvoiceRepository> _mockRepo;

    public GetAllInvoicesHandlerTests()
    {
        _mockRepo = MockInvoiceRepository.GetInvoiceRepository();

        var mapperProfile = new MapperConfiguration(i => i.AddProfile<InvoiceMapperProfile>());

        _mapper = mapperProfile.CreateMapper();
    }

    [Fact]
    public async Task GetAllInvoicesReturnsCorrectResponse()
    {
        var handler = new GetAllInvoicesHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetAllInvoicesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<InvoiceModel>>();

        result.Count().ShouldBe(2);
    }

    [Fact]
    public async Task GetAllInvoicesReturnsCorrectItemCount()
    {
        var handler = new GetAllInvoicesHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetAllInvoicesQuery(), CancellationToken.None);

        result.Count().ShouldBe(2);
    }

}

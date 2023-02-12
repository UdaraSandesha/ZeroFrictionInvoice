using AutoMapper;
using ZeroFrictionInvoice.Application.Commands;
using ZeroFrictionInvoice.Application.Models;
using ZeroFrictionInvoice.Domain.Entities.Invoices;

namespace ZeroFrictionInvoice.Application.Mappers;

public class InvoiceMapperProfile : Profile
{
    public InvoiceMapperProfile()
    {
        CreateMap<Invoice, InvoiceModel>();
        CreateMap<InvoiceLine, InvoiceLineModel>();
        CreateMap<CreateInvoiceCommand, Invoice>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid().ToString()));
        CreateMap<InvoiceLineModel, InvoiceLine>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid().ToString()));
    }
}
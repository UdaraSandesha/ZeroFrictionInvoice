using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ZeroFrictionInvoice.Application.Responses;
using ZeroFrictionInvoice.Domain.Repositories;
using ZeroFrictionInvoice.Domain.Repositories.Invoices;
using ZeroFrictionInvoice.Persistence;
using ZeroFrictionInvoice.Persistence.Repositories;
using ZeroFrictionInvoice.Persistence.Repositories.Invoices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(BaseResponse).Assembly);

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Configure cosmos dbcontext
var cosmosAccountEndpoint = config.GetSection("Azure:CosmosDb:AccountEndpoint").Value;
var cosmosAccountKey = config.GetSection("Azure:CosmosDb:AccountKey").Value;
var cosmosDatabaseName = config.GetSection("Azure:CosmosDb:DatabaseName").Value;

builder.Services.AddDbContext<ZeroFrictionInvoiceDbContext>(options => options.UseCosmos(cosmosAccountEndpoint, cosmosAccountKey, cosmosDatabaseName));

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(BaseResponse).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

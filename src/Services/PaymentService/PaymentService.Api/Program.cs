using PaymentService.Business.Extensions;
using PaymentService.Messages.Producers;
using SelenyumMicroService.Bootstrapper;
using SelenyumMicroService.MessageService;
using SelenyumMicroService.ServiceDiscovery.Consul;

var builder = WebApplication.CreateBuilder(args);
var urls = builder.Configuration.GetValue<string>("Urls") ?? Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
ArgumentNullException.ThrowIfNull(urls);

var messageServiceConnectionSettings = new MessageServiceConnectionSettings();
builder.Configuration.GetSection("RabbitMQ").Bind(messageServiceConnectionSettings);
ArgumentNullException.ThrowIfNull(messageServiceConnectionSettings);

// Add services to the container.
builder.Services.AddDefaultAuthentication(builder.Configuration);
builder.Services.AddMessageService(messageServiceConnectionSettings);
builder.Services.AddProducers();
builder.Services.AddBusiness();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var consulAddress = builder.Configuration["Consul:Address"];
ArgumentNullException.ThrowIfNull(consulAddress);

var consulSettings = new ConsulSettings(consulAddress, "PaymentService", "PaymentService", urls, [Environment.MachineName]);

builder.Services.AddConsul(consulSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseConsul(app.Lifetime, consulSettings);

app.Run(urls);
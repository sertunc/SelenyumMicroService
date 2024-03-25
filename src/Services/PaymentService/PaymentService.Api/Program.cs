using PaymentService.Messages.Producers;
using SelenyumMicroService.MessageService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var messageServiceConnectionSettings = new MessageServiceConnectionSettings();
builder.Configuration.GetSection("RabbitMQ").Bind(messageServiceConnectionSettings);
ArgumentNullException.ThrowIfNull(messageServiceConnectionSettings);

builder.Services.AddSingleton(messageServiceConnectionSettings);
builder.Services.AddMessageService(messageServiceConnectionSettings);
builder.Services.AddProducers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
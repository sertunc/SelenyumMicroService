using BasketService.Api.Extensions;
using BasketService.Business.Extensions;
using BasketService.Business.Mapping;
using BasketService.Data.Redis.Extensions;
using BasketService.Messages.Producers.MassTransit;
using SelenyumMicroService.Bootstrapper;
using SelenyumMicroService.Caching.Redis;
using SelenyumMicroService.MessageService;
using SelenyumMicroService.ServiceDiscovery.Consul;

var builder = WebApplication.CreateBuilder(args);
var urls = builder.Configuration.GetValue<string>("Urls") ?? Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
ArgumentNullException.ThrowIfNull(urls);

RedisSettings redisSettings = new();
builder.Configuration.GetSection("Redis").Bind(redisSettings);
ArgumentNullException.ThrowIfNull(redisSettings);

var messageServiceConnectionSettings = new MessageServiceConnectionSettings();
builder.Configuration.GetSection("RabbitMQ").Bind(messageServiceConnectionSettings);
ArgumentNullException.ThrowIfNull(messageServiceConnectionSettings);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddDefaultAuthentication(builder.Configuration);
builder.Services.AddRedisCacheService(redisSettings);
builder.Services.AddMessageService(messageServiceConnectionSettings);
builder.Services.AddAutoMapper<MappingProfile>();
builder.Services.AddRepositories();
builder.Services.AddBusiness();
builder.Services.AddProducers();
builder.Services.AddHttpClients(builder.Configuration);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var consulAddress = builder.Configuration["Consul:Address"];
ArgumentNullException.ThrowIfNull(consulAddress);

var consulSettings = new ConsulSettings(consulAddress, "BasketService", "BasketService", urls, [Environment.MachineName]);

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
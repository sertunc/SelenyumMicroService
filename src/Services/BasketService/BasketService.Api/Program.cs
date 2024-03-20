using SelenyumMicroService.ServiceDiscovery.Consul;

var builder = WebApplication.CreateBuilder(args);
var urls = builder.Configuration.GetValue<string>("Urls") ?? Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
ArgumentNullException.ThrowIfNull(urls);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var consulAddress = builder.Configuration["Consul:Address"];
ArgumentNullException.ThrowIfNull(consulAddress);
var consulSettings = new ConsulSettings
{
    ConsulAddress = consulAddress,
    ServiceId = "BasketService",
    ServiceName = "BasketService",//Web.ApiGateway->/Configurations/ocelot.json -> ServiceName
    ServiceHostUrl = urls,
    Tags = [Environment.MachineName]
};
builder.Services.AddConsul(consulSettings);

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

app.UseConsul(app.Lifetime, consulSettings);

app.Run(urls);
using IdentityService.Api.BusinessAbstractions;
using IdentityService.Api.Extensions;
using SelenyumMicroService.Bootstrapper;
using SelenyumMicroService.ServiceDiscovery.Consul;

var builder = WebApplication.CreateBuilder(args);
var urls = builder.Configuration.GetValue<string>("Urls") ?? Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
ArgumentNullException.ThrowIfNull(urls);

// Add services to the container.
builder.Services.AddDbContextConfigurations(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDefaultAuthentication(builder.Configuration);
builder.Services.AddScoped<IIdentityService, IdentityService.Api.Business.IdentityService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var consulAddress = builder.Configuration["Consul:Address"];
ArgumentNullException.ThrowIfNull(consulAddress);

var consulSettings = new ConsulSettings(consulAddress, "IdentityService", "IdentityService", urls, [Environment.MachineName]); //Web.ApiGateway->/Configurations/ocelot.json -> ServiceName

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
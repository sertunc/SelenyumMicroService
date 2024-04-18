using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

const string policyName = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOcelot(builder.Configuration).AddConsul();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      policy =>
                      {
                          policy.WithOrigins(["http://localhost:5173", "http://www.selenyum.com"])
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

builder.Configuration.AddJsonFile("Configurations/ocelot.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();
await app.RunAsync();
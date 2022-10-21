using Sihri.Flight;
using Sihri.Infrastructure;
using Sihri.Visa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddVisaServices(builder.Configuration);
builder.Services.AddFlightServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.InfraStructureStartupConfigure();
app.VisaStartupConfigure();
app.FlightStartupConfigure();

app.Run();

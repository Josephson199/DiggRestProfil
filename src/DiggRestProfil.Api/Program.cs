using CORP.DiggRestProfil.Middlewares;
using DiggRestProfil.Infrastructure.Data.Extensions;
using Serilog;
using Serilog.Sinks.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDapperNpgSql("");

var logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(builder.Configuration)
                        .Enrich.FromLogContext()
                        .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddResponseCaching();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.UseETagger();

app.MapControllers();

app.Run();

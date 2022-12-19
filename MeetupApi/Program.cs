using Contracts;
using Entities.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using MeetupApi.Extensions;
using MeetupApi.Validators;
using Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

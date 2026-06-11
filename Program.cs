using CleanMediator.Behaviors;
using CleanMediator.Infrastructure.Data.AppDbContext;
using CleanMediator.Infrastructure.Repository;
using CleanMediator.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("clean_mediator_db");
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(cfg=>
{
   cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);  
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>(); 

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:8081")
    .CreateLogger();


builder.Services.AddSerilog(); 

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers(); 

app.Run();


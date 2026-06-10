using CleanMediator.Infrastructure.Data.AppDbContext;
using CleanMediator.Infrastructure.Repository;
using CleanMediator.Interfaces;
using Microsoft.EntityFrameworkCore;

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

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers(); 

app.Run();


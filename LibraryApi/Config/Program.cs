using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using LibraryApi;
using LibraryApi.Entity;
using LibraryApi.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseInMemoryDatabase("LibraryApi"));
builder.Services.AddSwaggerGen(c =>

    c.SwaggerDoc("v1", new() { Title = "LibraryApi", Version = "v1" }));

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryApi"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
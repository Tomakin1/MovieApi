using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>();

// CATEGORY DI REGISTRATION
builder.Services.AddScoped<GetCategoryQueryHandler>();  // controllerda DI ile Kullanýlan servisleri burda kaydediyosun
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

// MOVÝE DI REGISTRATION
builder.Services.AddScoped<GetMovieQueryHandler>();  // controllerda DI ile Kullanýlan servisleri burda kaydediyosun
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

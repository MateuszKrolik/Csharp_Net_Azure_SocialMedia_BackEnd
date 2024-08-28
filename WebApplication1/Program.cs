using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.ExceptionHandlers;
using WebApplication1.Services;
using WebApplication1.Services.CoordinatesService;
using WebApplication1.Services.ImageService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlaceService, PlaceServiceImpl>();
builder.Services.AddHttpClient<ICoordinatesService, CoordinatesServiceImpl>();
// ExceptionHandlers are called in order of registration
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IImageService, ImageServiceImpl>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Configuration.AddUserSecrets<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

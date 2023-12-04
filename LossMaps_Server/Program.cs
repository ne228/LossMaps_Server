using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlite("Data Source=yourdatabase.db"));


builder.Services.AddScoped<StatementRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePathBase("/lossmaps");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using (var context = new YourDbContext())
{
    context.Database.EnsureCreated();
}

using EMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Services (The Professional .NET 8 Way)
builder.Services.AddControllers(); // Enables standard API Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Uses Swashbuckle for documentation

// 2. Connect the Database
// This reads the "DefaultConnection" string we added to appsettings.json earlier
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Configure the HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    // Generates the Swagger JSON
    app.UseSwaggerUI();  // Generates the UI webpage
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Maps the incoming requests to your Controllers

app.Run();
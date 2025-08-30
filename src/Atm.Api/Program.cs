var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service for standardized error responses (RFC 7807)
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseStatusCodePages(); // Optional: provides simple text-based responses for status codes like 404
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

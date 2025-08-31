using Atm.Application.Services;
using Atm.Domain.Enums;
using Atm.Domain.Models;
using Atm.Infrastructure.DataBaseContext;
using Atm.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database Context

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open(); // Keep the connection open for application lifetime

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connection);
});

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

#endregion

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountService, AccountService>();


// Service for standardized error responses (RFC 7807)
builder.Services.AddProblemDetails();

var app = builder.Build();

//Create database schema when the app starts.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();

    // Add some initial data
    if (!dbContext.Accounts.Any())
    {
        dbContext.Accounts.AddRange(
            new Account { Id = 2001, FirstName = "Michael", LastName = "King", AccountType = AccountType.Checking },
            new Account { Id = 2002, FirstName = "Michael", LastName = "King", AccountType = AccountType.Savings }
        );
        dbContext.Transactions.AddRange(
            new Transaction { Id = 1001, AccountId = 2001, Amount = 5000, TransactionDate = new DateTime(2025,08,01), Type = TransactionType.Credit},
            new Transaction { Id = 1002, AccountId = 2002, Amount = 2500, TransactionDate = new DateTime(2025, 08, 02), Type = TransactionType.Credit },
            new Transaction { Id = 1003, AccountId = 2001, Amount = 250, TransactionDate = new DateTime(2025, 08, 02), Type = TransactionType.Debit },
            new Transaction { Id = 1004, AccountId = 2001, Amount = 700, TransactionDate = new DateTime(2025, 08, 03), Type = TransactionType.Debit },
            new Transaction { Id = 1005, AccountId = 2002, Amount = 180, TransactionDate = new DateTime(2025, 08, 04), Type = TransactionType.Debit }
        );
        dbContext.SaveChanges();
    }
}

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

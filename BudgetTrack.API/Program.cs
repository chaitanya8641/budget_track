using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BudgetTrack.Data;
using BudgetTrack.Domain.Entities;
using BudgetTrack.API.Services.Interfaces;
using BudgetTrack.API.Services;
using BudgetTrack.Common;
using BudgetTrack.API.Mapping;
using BudgetTrack.BAL.Interfaces;
using BudgetTrack.DAL;
using BudgetTrack.BAL.Services;
using BudgetTrack.DAL.Interfaces;
using BudgetTrack.API.Exceptions;
using BudgetTrack.Domain.Enums;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["AppSettings:Issuer"],
        ValidAudience = configuration["AppSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:SecretKey"]))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
}).AddXmlSerializerFormatters();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BudgetTracker API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Dependencies
builder.Services.AddDbContext<BudgetContext>(options =>
{
    options.UseInMemoryDatabase("BudgetTracker");
    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});


builder.Services.AddDbContext<BudgetContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddScoped<IUserTransactionService, UserTransactionService>();
builder.Services.AddScoped<IUserAccountBalanceRepository, UserAccountBalanceRepository>();
builder.Services.AddScoped<IUserAccountBalanceService, UserAccountBalanceService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global error handler
app.UseMiddleware<ExceptionsHandlingMiddleware>();


// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


CreateUser(app);
CreateUserTransaction(app);
CreateUserAccountBalance(app);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void CreateUser(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<BudgetContext>();
    var users = db?.Users;

    if (users != null)
        db?.Users?.RemoveRange(users);

    db?.SaveChanges();
    var testUsers = new List<User>() {
        new User
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            UserName = "HGibbs",
            Password = "Testing@01"
        }
    };

    db?.Users?.AddRange(testUsers);
    db?.SaveChanges();
}

static void CreateUserTransaction(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<BudgetContext>();
    var userTransaction = db?.UserTransactions;

    if (userTransaction != null)
        db?.UserTransactions?.RemoveRange(userTransaction);

    db?.SaveChanges();
    var testUserTransaction = new List<UserTransaction>() {
        new UserTransaction
        {
            TransactionId = new Guid("3fa85f64-5717-9999-b3fc-2c963f66afa6"),
            UserId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            TransactionName = "Online",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            TransactionAmount = 100,
            Type = TransactionType.Debit.ToString(),
        }
    };

    db?.UserTransactions?.AddRange(testUserTransaction);
    db?.SaveChanges();
}

static void CreateUserAccountBalance(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<BudgetContext>();
    var userAccountBalance = db?.UserAccountBalance;

    if (userAccountBalance != null)
        db?.UserAccountBalance?.RemoveRange(userAccountBalance);

    db?.SaveChanges();
    var testUserAccountBalance = new List<UserAccountBalance>() {
        new UserAccountBalance
        {
            UserAccountBalanceId = new Guid("3fa85f64-5717-4562-b3fc-3c963f66afb7"),
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Type = TransactionType.Debit.ToString(),
            AccounrBalance = 34000
        },
        new UserAccountBalance
        {
            UserAccountBalanceId = new Guid("3fa85f64-7777-4562-b3fc-3c963f66afb7"),
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Type = TransactionType.Credit.ToString(),
            AccounrBalance = 50000
        }
    };

    db?.UserAccountBalance?.AddRange(testUserAccountBalance);
    db?.SaveChanges();
}

public partial class Program { }
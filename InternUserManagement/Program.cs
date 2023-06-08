using InternUserManagement.Interfaces;
using InternUserManagement.Models;
using InternUserManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDbContext<UserContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});
builder.Services.AddScoped<IRepo<int, User>, USerRepo>();
builder.Services.AddScoped<IRepo<int, Intern>, InternRepo>();
builder.Services.AddScoped<IGeneratePassword,GeneratePasswordService>();
builder.Services.AddScoped<IManageUser, ManageUserService>();
builder.Services.AddScoped<IGenerateToken, GenerateTokenService>();
builder.Services.AddScoped<IFunction<User>,USerRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AngularCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

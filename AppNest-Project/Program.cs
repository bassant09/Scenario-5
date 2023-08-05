using AppNest_Project.Data;
using AppNest_Project.Services.AuthServices;
using AppNest_Project.Services.BookingServices;
using AppNest_Project.Services.FileServices;
using AppNest_Project.Services.ResourcesServices;
using AppNest_Project.Services.ResourcesShelter;
using AppNest_Project.Services.ShelterServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer Scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IShelterServices, ShelterServices>();
builder.Services.AddScoped<IResourceServices, ResourceServices>();
builder.Services.AddScoped<IBookServices, BookingServices>();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
     AddJwtBearer(option =>
     {
         option.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
             GetBytes(builder.Configuration.GetSection("AppSetting:Token").Value)),
             ValidateIssuer = false,
             ValidateAudience = false,

         };
     });

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();
app.UseStaticFiles();
app.UseDefaultFiles();

app.Run();

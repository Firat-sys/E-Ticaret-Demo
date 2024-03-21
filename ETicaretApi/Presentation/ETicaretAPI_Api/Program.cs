using ETicaretApiPersistence;
using ETicaretApplication;
using ETicaretApplication.Validators.Products;
using ETicaretInfrastructure;
using ETicaretInfrastructure.Filters;
using ETicaretInfrastructure.Services.Storage.Azure;
using ETicaretInfrastructure.Services.Storage.Local;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

builder.Services.AddCors(options=>
options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddControllers(option=>option.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration=>configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidators>())
    .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Olu?turulacak token de?erini kimlerin/hangi originlerin/sitelerin kullan?c? belirledi?imiz de?erdir. -> www.bilmemne.com
            ValidateIssuer = true, //Olu?turulacak token de?erini kimin da??tt?n? ifade edece?imiz aland?r. -> www.myapi.com
            ValidateLifetime = true, //Olu?turulan token de?erinin süresini kontrol edecek olan do?rulamad?r.
            ValidateIssuerSigningKey = true, //Üretilecek token de?erinin uygulamam?za ait bir de?er oldu?unu ifade eden suciry key verisinin do?rulanmas?d?r.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            //LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            //NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne kar??l?k gelen de?eri User.Identity.Name propertysinden elde edebiliriz.
        };
    });


builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP req uest pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

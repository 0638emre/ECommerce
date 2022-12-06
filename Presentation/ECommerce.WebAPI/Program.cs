using System.Text;
using ECommerce.Application;
using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Filters;
using ECommerce.Infrastructure.Services.Storage.Azure;
using ECommerce.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//IOC Container
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4401", "https://localhost:4401").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

//IOCler
builder.Services.AddPersistanceServices(builder.Configuration);
//AddPersistanceServices tarafýmýzdan extension metot olarak persistance katmaný altýnda yazýldý. Buradaki amaç api katmanýnda istediðimiz bir servisi çaðýrarak kullanmak-
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

//builder.Services.Add(StorageType.Azure);
//builder.Services.AddStorage(ECommerce.Infrastructure.Enums.StorageType.Local); // bu þekilde de mimari ne ile çalýþacaksa storage olarak onu enum üzerinden seçebiliriz.
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=> options.SuppressModelStateInvalidFilter = true);
//burada fluent val. ile gelen isteðin bizim tuttuðumuz rule lara uygun olup olmadýðýna bakarak cliente bilgi verir. Validation application katmanýnda olduðundan oradaki herhani bir validators class vermemiz yeterli olacaktýr. diðer validator class larý vermemize gerek yoktur. tanýr.
//Validation Filter (infrastruxter katmanýndan devreye giriyor ki her gelen istek o filtreden geçsin. handle olsun.)



builder.Services.AddEndpointsApiExplorer();

//swagger ayarlarýný buradan config ediyoruz
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Token aliyim :)",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});
//builder.Services.AddSwaggerGen();

//jwt configirasyonu BURASI OLUÞAN BÝR TOKEN I OKUMAK ÝÇÝN GEREKLÝ OLAN KONFÝGURASYONDUR
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //oluþturulacak token deðerini kimlerin hangi originlerin hangi web sitelerinin kullanýlacaðýný belirleriz
            ValidateIssuer = true, // oluþturulacak toekn deðerini kimin daðýttýðýný ifade edeceðimiz alandýr.
            ValidateLifetime = true, //oluþturulacak token deðerinin süresini tutacak alandýr
            ValidateIssuerSigningKey = true, //oluþturulacak token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden security keydir.
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

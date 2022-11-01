using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Filters;
using ECommerce.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//IOC Container
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

//IOCler
builder.Services.AddPersistanceServices(builder.Configuration);
//AddPersistanceServices taraf�m�zdan extension metot olarak persistance katman� alt�nda yaz�ld�. Buradaki ama� api katman�nda istedi�imiz bir servisi �a��rarak kullanmak-
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=> options.SuppressModelStateInvalidFilter = true);
//burada fluent val. ile gelen iste�in bizim tuttu�umuz rule lara uygun olup olmad���na bakarak cliente bilgi verir. Validation application katman�nda oldu�undan oradaki herhani bir validators class vermemiz yeterli olacakt�r. di�er validator class lar� vermemize gerek yoktur. tan�r.
//Validation Filter (infrastruxter katman�ndan devreye giriyor ki her gelen istek o filtreden ge�sin. handle olsun.)



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

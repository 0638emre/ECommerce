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
//AddPersistanceServices tarafýmýzdan extension metot olarak persistance katmaný altýnda yazýldý. Buradaki amaç api katmanýnda istediðimiz bir servisi çaðýrarak kullanmak-
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=> options.SuppressModelStateInvalidFilter = true);
//burada fluent val. ile gelen isteðin bizim tuttuðumuz rule lara uygun olup olmadýðýna bakarak cliente bilgi verir. Validation application katmanýnda olduðundan oradaki herhani bir validators class vermemiz yeterli olacaktýr. diðer validator class larý vermemize gerek yoktur. tanýr.
//Validation Filter (infrastruxter katmanýndan devreye giriyor ki her gelen istek o filtreden geçsin. handle olsun.)



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

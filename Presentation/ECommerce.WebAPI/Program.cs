using ECommerce.Persistance;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//IOC Container
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));
builder.Services.AddPersistanceServices(builder.Configuration);
//AddPersistanceServices taraf�m�zdan extension metot olarak persistance katman� alt�nda yaz�ld�. Buradaki ama� api katman�nda istedi�imiz bir servisi �a��rarak kullanmak-

builder.Services.AddControllers();

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
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

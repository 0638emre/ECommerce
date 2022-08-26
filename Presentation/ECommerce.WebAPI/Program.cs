using ECommerce.Persistance;

var builder = WebApplication.CreateBuilder(args);
//IOC Container
builder.Services.AddPersistanceServices(builder.Configuration);
//AddPersistanceServices tarafýmýzdan extension metot olarak persistance katmaný altýnda yazýldý. Buradaki amaç api katmanýnda istediðimiz bir servisi çaðýrarak kullanmak-

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

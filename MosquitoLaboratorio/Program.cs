using MosquitoLaboratorio.DbContext;
using MosquitoLaboratorio.Repositories.Auth;
using MosquitoLaboratorio.Services.Auth;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(provider => new DBContext(builder.Configuration.GetConnectionString("PostgreSQLConnection")!));

builder.Services.AddScoped<IAuthRepository,  AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

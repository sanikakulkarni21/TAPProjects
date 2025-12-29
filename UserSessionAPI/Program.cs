using UserSessionAPI.Repository.Interfaces;

using UserSessionAPI.Repository.Interfaces;
using UserSessionAPI.Repository.Implementations;
using UserSessionAPI.services.Interfaces;
using UserSessionAPI.services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // IMPORTANT
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IuserSessionService, userSessionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

/*pp.UseHttpsRedirection(); */
app.UseAuthorization();

app.MapControllers();

app.Run();


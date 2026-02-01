
using Grpc.Core;
using Hospital; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AppointmentServiceImpl >();
app.MapGet("/", () => "Grpc service is running");

app.Run();

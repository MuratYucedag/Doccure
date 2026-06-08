using Doccure.QueueService.Context;
using Doccure.QueueService.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QueueContext>();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SignalRCorsPolicy", policy =>
    {
        policy
            .WithOrigins("https://localhost:7078")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors("SignalRCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapHub<QueueHub>("/queuehub");

app.Run();

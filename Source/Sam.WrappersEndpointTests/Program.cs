var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAppExceptionHandling(p =>
{
    //p.StatusCode = 400;
    //p.JsonSerializerOptions = new JsonSerializerOptions()
    //{
    //    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    //};
});

var app = builder.Build();

app.UseAppExceptionHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

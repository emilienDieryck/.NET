using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/TVA", (double price, string country) =>
{
    if (country.Equals("BE"))
    {
        return (price + (price * 0.21)).ToString();
    }
    else if (country.Equals("FR"))
    {
        return (price + (price * 0.20)).ToString();
    }
    else
    {
        return "Country not supported";
    }
});



app.Run();


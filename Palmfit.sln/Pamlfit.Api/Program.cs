using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Configure NLog
var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
try
{
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();  // Use NLog for logging
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped because of an exception");
    throw;
}

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

try
{
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped because of an exception");
    throw;
}
finally
{
    LogManager.Shutdown(); // Ensure to flush and close down internal loggers
}

using implement.Core.Model.Base;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
#region SeriLogInjection
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();
Log.Logger.Information("Starting up");
#endregion

#region Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.AddSwaggerGen();

#endregion

#region SeriLogConfigure
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
.WriteTo.File(
        $@"{appSettings.LogFilePath}{appSettings.LogFileName}.txt",
        rollingInterval: (RollingInterval.Day),
        fileSizeLimitBytes: (appSettings.LogFileSizeMB * 1000000),
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: null)
    .CreateLogger();
#endregion

#region App
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion


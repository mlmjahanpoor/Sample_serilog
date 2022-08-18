using Sample_Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

#region serilog

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(new JsonFormatter())
    .WriteTo.Seq("http://localhost:5185")
        .WriteTo.File(new JsonFormatter(), "log.txt")
        .WriteTo.MSSqlServer("Data Source=.;Initial Catalog=testDb;Integrated Security=true",
                         new MSSqlServerSinkOptions
                         {
                             TableName = "Logs",
                             SchemaName = "dbo",
                             AutoCreateSqlTable = true
                         }, null, null, LogEventLevel.Information, null, SerilogColumnOptions.GetColumnOptions())
    );

#endregion serilog

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
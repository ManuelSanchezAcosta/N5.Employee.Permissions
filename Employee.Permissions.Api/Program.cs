using Employee.Permissions.Api;
using Employee.Permissions.Infrastructure;
using Employee.Permissions.Application;
using Employee.Permissions.Api.Extensions;
using Employee.Permissions.Api.Middlewares;
using N5.Shared.ElasticSearch;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Host.UseSerilog();

//Custom for my App
builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication()                 
                .AddElasticsearch(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}


app.UseExceptionHandler("/error");

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

// Global error control
app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

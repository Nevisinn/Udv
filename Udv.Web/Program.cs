using System.Reflection;
using Udv.Core.Interfaces;
using Udv.Core.Services;
using Udv.Infrastructure.DbContext;
using Udv.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped<IPostCollector, PostCollector>();
builder.Services.AddScoped<ILetterCounter, LetterCounter>();
builder.Services.AddScoped<IPostLetterStatsRepository, PostLetterStatsRepository>();
builder.Services.AddScoped<IPostLetterFrequencyService, PostLetterFrequencyService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory!.AddFile($"Logs/{Assembly.GetExecutingAssembly().GetName().Name}.log");    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();

app.Run();

using Microsoft.EntityFrameworkCore;
using PowerOutageReporter.Data;
using PowerOutageReporter.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnectionString = builder.Configuration.GetConnectionString("Incidents")!;
builder.Services.AddDbContext<IncidentDbContext>((serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString), optionsBuilder => optionsBuilder
        .EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null));

    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.EnableSensitiveDataLogging();
});
builder.Services.AddRazorPages();
builder.Services.AddScoped(serviceProvider => new IncidentRepository(serviceProvider.GetRequiredService<IncidentDbContext>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


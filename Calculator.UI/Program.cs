using Calculator.Core.Data;
using Calculator.Core.Processor;
using Calculator.Core.Wrappers;
using Calculator.UI.Controllers;
using Calculator.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IFileWriter, FileWriter>();
builder.Services.AddSingleton<IProbabilityRepository, ProbabilityRepository>();
builder.Services.AddSingleton<IProbabilityProcessor, ProbabilityProcessor>();
builder.Services.AddSingleton<ProbabilityCalculationController>();
builder.Services.AddSingleton<IProbabilityCalculationService, ProbabilityCalculationService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

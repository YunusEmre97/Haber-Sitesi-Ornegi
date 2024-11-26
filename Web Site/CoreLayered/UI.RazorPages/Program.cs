using Business;
using Core.Abstracts.IServices;
using Utility.Generics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//builder.Configuration : appsettings.json dosyas�n� okuyan yap�.
builder.Services.AddDataTransactions(builder.Configuration);
builder.Services.AddTransient(typeof(Pagination<>));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();

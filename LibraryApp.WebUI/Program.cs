using LibraryApp.Business.Abstract;
using LibraryApp.Business.Concrete;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBorrowedBookRepository, EfBorrowedBookRepository>();
builder.Services.AddScoped<IBorrowedBookService, BorrowedBookManager>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "kitapekle",
    pattern: "kitapekle",
    defaults: new { controller = "Home", action = "Create" }
);

app.MapControllerRoute(
    name: "oduncver",
    pattern: "oduncver",
    defaults: new { controller = "Home", action = "BorrowBook" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

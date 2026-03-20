using ToDoApp.Data.Context;
using ToDoApp.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews
(opt => 
{
    opt.Filters.Add<CancellationExceptionFilter>();
});
builder.Services.AddDbContext<ToDoContext>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute
   (
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}"
   ).WithStaticAssets();

app.Run();

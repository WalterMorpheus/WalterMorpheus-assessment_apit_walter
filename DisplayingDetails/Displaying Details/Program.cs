using Displaying_Details.Extensions;
using Repo.Data.Seed;
using Repo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region load Custom Extensions 
/* This connects to the custom Extensions class*/
builder.Services.AddApplicationServices(builder.Configuration);
#endregion

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


#region Entity Framework custom code
/*This handles the database migration*/
try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ClientDbContext>();

    /*Any pending Migration changes will be executed when the program first runs (Any tables the need to be added to the database, if the database dose not exists will be created)*/
    await context.Database.MigrateAsync();
    /*This inserts any data maybe required in the tables*/
    await Seed.Initial(context);
}
catch (Exception ex)
{
    /*In case the magration fails for any reason, this log the error for further analysis*/
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");

}
#endregion

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

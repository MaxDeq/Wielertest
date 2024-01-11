using Microsoft.EntityFrameworkCore;
using Test.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Toevoegen zodat database werkt
builder.Services.AddDbContext<WielerwedstrijdDbContext>(options =>
{
	options.UseInMemoryDatabase(nameof(WielerwedstrijdDbContext));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
// ook toegevoegd, zodat browser weet ofdat hij gegevens moet bijhouden of niet
else
{
	{
		var scope = app.Services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<WielerwedstrijdDbContext>();

		if (dbContext.Database.IsInMemory())
		{
			dbContext.Seed();
		}
	}
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

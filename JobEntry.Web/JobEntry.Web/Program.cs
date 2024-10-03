using JobEntity.DataAccess;
using JobEntity.DataAccess.Context;
using JobEntry.Business;
using JobEntity.DataAccess.Seed;
using Microsoft.EntityFrameworkCore;
using JobEntry.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using JobEntry.Web;
using NToastNotify;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        ProgressBar = false,
		CloseButton = true,
		ShowDuration = 3000,
		TimeOut =3000,
        PositionClass = ToastPositions.TopRight
    });
builder.Services.LoadMvcServices(builder.Configuration);
builder.Services.LoadDataAccessServices(builder.Configuration);
builder.Services.LoadBusinessServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseNToastNotify();
app.UseExceptionHandlerMiddleware(); //Custome Exception Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name:"Admin",
		areaName: "Admin",
		pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapDefaultControllerRoute();
});

#region ContextSeed
using var scope = app.Services.CreateScope();
try
{
	var contextSeedService = scope.ServiceProvider.GetService<ContextSeedData>();
	await contextSeedService.InitializeContextAsync();
}
catch (Exception ex)
{
	var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
	logger.LogError(ex.Message, "Failed to initialize and seed the database");
	throw;
}
#endregion

app.Run();

using Finance.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinanceContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("FinanceContext") ?? throw new InvalidOperationException("Connection string 'FinanceContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FinanceContext>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new[] { "pt-BR" };
	var cultureInfo = new CultureInfo("pt-BR");

	options.DefaultRequestCulture = new RequestCulture(cultureInfo);
	options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
	options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		builder => builder.WithOrigins("http://localhost:4200")
							.AllowAnyHeader()
							.AllowAnyMethod());
});

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
app.UseCors("AllowSpecificOrigin");
app.UseRouting();

app.UseAuthorization();
app.UseRequestLocalization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

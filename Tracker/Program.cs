using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tracker.Mappings;
using Tracker.Persistence;
using Tracker.Services.Implementations;
using Tracker.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

//Add DbContext Services 
builder.Services.AddDbContextPool<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add BTS Service
builder.Services.AddScoped<IBaseStationService, BaseStationService>();

//Add Client Service
builder.Services.AddScoped<IClientService, ClientService>();

//Add Circuit Service
builder.Services.AddScoped<ICircuitService, CircuitService>();

//Add Employee Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

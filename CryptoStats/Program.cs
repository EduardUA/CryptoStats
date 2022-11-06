using CryptoStats.Data;
using CryptoStats.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Overide the configuration 
builder.Services.Configure<IdentityOptions>(opt =>
    {
        // Password settings 
        opt.Password.RequireDigit = true;
        opt.Password.RequiredLength = 8;
        // Lockout settings 
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
        opt.Lockout.MaxFailedAccessAttempts = 5;
        //Signin option
        opt.SignIn.RequireConfirmedEmail = false;
        // User settings 
        opt.User.RequireUniqueEmail = true;        
    });

// Cookie settings 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.MaxAge = TimeSpan.FromHours(12);    
    options.LoginPath = "/Identity/Login";
    options.LogoutPath = "/Identity/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

StaticFileOptions staticFileOptions = new StaticFileOptions();
FileExtensionContentTypeProvider typeProvider = new FileExtensionContentTypeProvider();
if (!typeProvider.Mappings.ContainsKey(".woff2"))
{
    typeProvider.Mappings.Add(".woff2", "application/font-woff2");
}

if (!typeProvider.Mappings.ContainsKey(".woff"))
{
    typeProvider.Mappings.Add(".woff", "application/font-woff");
}

if (!typeProvider.Mappings.ContainsKey(".ttf"))
{
    typeProvider.Mappings.Add(".ttf", "application/font-ttf");
}
staticFileOptions.ContentTypeProvider = typeProvider;
app.UseStaticFiles(staticFileOptions);
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

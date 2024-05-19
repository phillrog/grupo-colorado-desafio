using Client.Web.Areas.Authentication;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Data;
using Client.Web.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddHttpClient<IClientesService, ClientesService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ClientesApi"])
);

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseExceptionHandler("/Error");

app.Use(async (ctx, next) =>
{
    await next();
    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
    {
        ctx.Request.Path = "/Error";
        await next();
    }
});

app.UseStatusCodePagesWithReExecute("/Error");

app.UseHsts();


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    app.SeedUsers(userManager, roleManager);
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

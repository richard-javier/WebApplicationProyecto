using Microsoft.EntityFrameworkCore;
using WebApplicationBackend;
using WebApplicationBackend.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de DbContext
builder.Services.AddDbContext<ApplicationDbContext>();

// Registrar los repositorios
builder.Services.AddScoped<IRepositorioForgotPassword, RepositorioForgotPassword>();
builder.Services.AddScoped<IRepositorioListaRegistros, RepositorioListaRegistros>();
builder.Services.AddScoped<IRepositorioRegister, RepositorioRegister>();
builder.Services.AddScoped<IRepositorioLogin, RepositorioLogin>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioCompra, RepositorioCompra>();
builder.Services.AddScoped<IRepositorioVenta, RepositorioVenta>();
builder.Services.AddScoped<IRepositorioInventario, RepositorioInventario>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using VendingMachine.Application.Initialisation;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.RegisterApplicationHandlers();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IVendingMachineRepository, VendingMachineRepository>();
//builder.Services.AddScoped<IUnitOfWork, SqlDbUnitOfWork>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IVendingMachineRepository, VendingMachineRepository>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();

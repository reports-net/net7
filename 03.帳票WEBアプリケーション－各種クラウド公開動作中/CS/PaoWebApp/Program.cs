var builder = WebApplication.CreateBuilder(args);

// EventLog�v���o�C�_�[�𖾎��I�ɏ��O
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Lifetime.ApplicationStarted.Register(() =>
{
    System.Diagnostics.Process.Start(
        new System.Diagnostics.ProcessStartInfo("http://localhost:5000") { UseShellExecute = true });
});

app.Run();
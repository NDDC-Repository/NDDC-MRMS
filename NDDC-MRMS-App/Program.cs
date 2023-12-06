using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using NddcMrmsLibrary.Data.EmployeeData;
using NddcMrmsLibrary.Data.Helper;
using NddcMrmsLibrary.Data.LabData;
using NddcMrmsLibrary.Data.Patient;
using NddcMrmsLibrary.Databases;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Step-1 In Adding Blazor
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IEmployeeData, SQLEmployee>();
builder.Services.AddTransient<ILabsData, SQLLabs>();
builder.Services.AddTransient<IPatientData, SqlPatient>();
builder.Services.AddTransient<IHelperData, SqlHelper>();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureADB2C"));

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to 
    // the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages(options => {
    options.Conventions.AllowAnonymousToPage("/Index");
    options.Conventions.AllowAnonymousToPage("/Reports/PayrollSummaryByDept");
    options.Conventions.AllowAnonymousToPage("/PdfPages/EmployeePayslip/");
})
.AddMvcOptions(options => { })
.AddMicrosoftIdentityUI();

var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk1MzIyMEAzMjMzMmUzMDJlMzBJZzd0bW5GTWtrL2ZoeURxdmFGS2tDY2VoWThQUU8rUkJobC8yK0thRzhvPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//step-2 in adding Blazor
app.MapBlazorHub();
app.MapControllers();

app.Run();

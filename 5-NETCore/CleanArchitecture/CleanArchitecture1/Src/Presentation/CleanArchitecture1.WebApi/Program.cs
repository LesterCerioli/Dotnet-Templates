using CleanArchitecture1.Application;
using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Infrastructure.FileManager;
using CleanArchitecture1.Infrastructure.FileManager.Contexts;
using CleanArchitecture1.Infrastructure.Identity;
using CleanArchitecture1.Infrastructure.Identity.Contexts;
using CleanArchitecture1.Infrastructure.Identity.Models;
using CleanArchitecture1.Infrastructure.Identity.Seeds;
using CleanArchitecture1.Infrastructure.Persistence;
using CleanArchitecture1.Infrastructure.Persistence.Contexts;
using CleanArchitecture1.Infrastructure.Persistence.Seeds;
using CleanArchitecture1.Infrastructure.Resources;
using CleanArchitecture1.WebApi.Infrastructure.Extensions;
using CleanArchitecture1.WebApi.Infrastructure.Middlewares;
using CleanArchitecture1.WebApi.Infrastructure.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddFileManagerInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddIdentityInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddResourcesInfrastructure();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSwaggerWithVersioning();
builder.Services.AddAnyCors();
builder.Services.AddCustomLocalization(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    if (!useInMemoryDatabase)
    {
        await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
        await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
        await services.GetRequiredService<FileManagerDbContext>().Database.MigrateAsync();
    }

    //Seed Data
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
    await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
}

app.UseCustomLocalization();
app.UseAnyCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");
app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();

public partial class Program
{
}

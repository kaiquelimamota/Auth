using Auth.Application.Modules.Auth.Interfaces;
using Auth.Application.Modules.Auth.Services;
using Auth.Domain.Models.Auth.Interfaces;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Refit;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRefitClient<IkeyCloackApi>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("http://localhost:8080/auth/realms");
});

builder.Services.AddRefitClient<IkeyCloackApiUser>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("http://localhost:8080/auth/admin/realms");
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserProvinderExample", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});


var authenticationOptions = builder
                            .Configuration
                            .GetSection(KeycloakAuthenticationOptions.Section)
                            .Get<KeycloakAuthenticationOptions>();

builder.Services.AddKeycloakAuthentication(authenticationOptions);

var authorizationOptions = builder
                            .Configuration
                            .GetSection(KeycloakProtectionClientOptions.Section)
                            .Get<KeycloakProtectionClientOptions>();

builder.Services.AddKeycloakAuthorization(authorizationOptions);

var adminClientOptions = builder
                            .Configuration
                            .GetSection(KeycloakAdminClientOptions.Section)
                            .Get<KeycloakAdminClientOptions>();

builder.Services.AddKeycloakAdminHttpClient(adminClientOptions);

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

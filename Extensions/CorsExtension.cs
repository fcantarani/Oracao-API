namespace Oracap_App_API.Extensions;

public static class CorsExtension
{
    public static void AddCors(this WebApplicationBuilder builder, string[] origins)
    {
        builder.Services.AddCors(action =>
            action.AddDefaultPolicy(policy =>
                policy.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));
    }
}

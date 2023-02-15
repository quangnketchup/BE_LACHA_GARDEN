using LachaGarden.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {

        Type = SecuritySchemeType.OAuth2,

        Flows = new OpenApiOAuthFlows
        {
            Password = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri("/v1/auth", UriKind.Relative),
                Extensions = new Dictionary<string, IOpenApiExtension>
                                {
                                    { "returnSecureToken", new OpenApiBoolean(true) },
                                },

            }

        }
    });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

var app = builder.Build();
app.Urls.Add("https://s2tek.net:7100");
app.Urls.Add("https://localhost:7100");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseSwagger()
          .UseSwaggerUI(c =>
          {
              c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Chivado Api");
          });
app.UseAuthorization();

app.MapControllers();

app.Run();

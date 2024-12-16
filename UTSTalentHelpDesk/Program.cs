using ElmahCore.Mvc;
using ElmahCore;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Config;

using UTSTalentHelpDesk.Repositories.Infrastructure.ServiceExtension;
using UTSTalentHelpDesk.Repositories.Interfaces;
using UTSTalentHelpDesk.Repositories.Repositories;
using UTSTalentHelpDesk.Middlewares;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();


builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.LogPath = configuration["ElmahCoreLogPath"];
    options.Notifiers.Add(new MyNotifier(configuration));
    options.Filters.Add(new CmsErrorLogFilter());
});


builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = configuration["JWT:Issuer"],
		ValidAudience = configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Key),
        ClockSkew = TimeSpan.Zero // Remove the default value 5m tolerance
    };
});

builder.Services.AddDirectoryBrowser();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
AppSettingProvider.SMTPEmailName = configuration["app_settings:SMTPEmailName"];
AppSettingProvider.SMTPPasswordName = configuration["app_settings:SMTPPasswordName"];
AppSettingProvider.SMTPClientName = configuration["app_settings:SMTPClientName"];
AppSettingProvider.SMTPSSLName = Convert.ToBoolean(configuration["app_settings:SMTPSSLName"]);
AppSettingProvider.SMTPPortName = Convert.ToInt32(configuration["app_settings:SMTPPortName"]);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services
        .AddAuthentication(o =>
        {
            // This forces challenge results to be handled by Google OpenID Handler, so there's no
            // need to add an AccountController that emits challenges for Login.
            o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // This forces forbid results to be handled by Google OpenID Handler, which checks if
            // extra scopes are required and does automatic incremental auth.
            o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // Default scheme that will handle everything else.
            // Once a user is authenticated, the OAuth2 token info is stored in cookies.
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie();
//.AddGoogleOpenIdConnect(options =>
//{
//    options.ClientId = configuration["GoogleAppClientID"];
//    options.ClientSecret = configuration["GoogleAppClientSecret"];
//});

//builder.Services.AddSwaggerGen(x =>
//{
//    x.SwaggerDoc("v1", new OpenApiInfo { Title = "UTS - ATS sync", Version = "v1" });
//    x.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
//    {
//        Name = "X-API-KEY",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "ApiKeyScheme",
//        In = ParameterLocation.Header,
//        Description = "ApiKey must appear in header"
//    });

//    x.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "X-API-KEY"
//                },
//                In = ParameterLocation.Header
//            },
//            new string[]{}
//        }
//    });
//});

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Talent Help Desk", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();




// Configure the HTTP request pipeline.

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ValidatorUrl(null);
    });
    app.UseDeveloperExceptionPage();
}

//app.UseMiddleware<RequestLoggingMiddleware>();
//app.UseMiddleware<ApiKeyMiddleware>();
//app.UseMiddleware<JwtMiddleware>();
app.UseCookiePolicy();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHsts();
app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' https://apis.google.com; style-src 'self' https://fonts.googleapis.com; img-src 'self' https://images.example.com data:; font-src 'self' https://fonts.gstatic.com; frame-ancestors 'self'");
    await next();
});
// Middleware to remove headers that may expose server information
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        // Remove other custom headers if necessary
        return Task.CompletedTask;
    });
    await next();
});
app.UseAuthentication();
app.UseAuthorization();
app.UseElmah();
app.MapControllers();
app.UseStaticFiles();


app.UseMiddleware<JwtMiddleware>();

// Websocket configuration
app.UseWebSockets();
//app.UseMiddleware<CustomWebSocketMiddleware>();

app.UseFileServer(new FileServerOptions()
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"Media/Images")
            
            ),
    RequestPath = new PathString("/Media"),
    EnableDirectoryBrowsing = true
});
app.Run();



using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HotelPMS.API.Middlewares;
using HotelPMS.Application;
using HotelPMS.Infrastructure;
using HotelPMS.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);


var jwtSettings = new JwtSettings();
builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));


builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanManageReservations", policy =>
        policy.RequireClaim("permission", "reservations:manage").RequireRole("Admin", "FrontOfficeManager", "Receptionist"));

    options.AddPolicy("CanRunNightAudit", policy =>
        policy.RequireClaim("permission", "nightaudit:run").RequireRole("Admin", "NightAuditor", "FinanceManager"));

    options.AddPolicy("CanAccessBilling", policy =>
        policy.RequireClaim("permission", "billing:access").RequireRole("Admin", "Cashier", "FinanceManager"));

    options.AddPolicy("CanManageRooms", policy =>
        policy.RequireClaim("permission", "rooms:manage").RequireRole("Admin", "FrontOfficeManager"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HotelPMS API", Version = "v1" });

    
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

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
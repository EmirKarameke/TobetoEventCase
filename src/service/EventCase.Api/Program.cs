using EventCase.Api.Filters;
using EventCase.Application.Contract.Events;
using EventCase.Application.Events;
using EventCase.Auth;
using EventCase.Auth.Permissions;
using EventCase.Auth.Roles;
using EventCase.Auth.Roles.RolePermissions;
using EventCase.Auth.Users;
using EventCase.Domain.Events;
using EventCase.EntityFrameworkCore;
using EventCase.EntityFrameworkCore.Events;
using EventCase.EntityFrameworkCore.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventCase API", Version = "v1" });

    // JWT için bir güvenlik þemasý ekleyin
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();


builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<EventCaseContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IUserRepository<Guid>, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository<Guid>, UserRoleRepository>();
builder.Services.AddScoped<IUserPermissionRepository<Guid>, UserPermissionRepository>();
builder.Services.AddScoped<IPermissionRepository<Guid>, PermissionRepository>();
builder.Services.AddScoped<IRoleRepository<Guid>, RoleRepository>();
builder.Services.AddScoped<IRolePermissionRepository<Guid>, RolePermissionRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddScoped<IAuthService<Guid>, AuthService<Guid>>();
builder.Services.AddScoped<IEventAppService, EventAppService>();
// JWT kimlik doðrulama servislerini ekleyin
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization((options) =>
{
    // iki rolden birine sahip olunmalý 
    //options.AddPolicy("AdminOrEditor", policy 
    //policy.RequireAssertion(context =>
    //    context.User.IsInRole("Admin") || context.User.IsInRole("Editor")));


    //policyler hepsi zorunlu 
    //options.AddPolicy("EmployeeOrMember", policy =>
    //    {
    //        policy.RequireClaim(ClaimTypes.Role, EventCasePermissions.Employee.Read);
    //        policy.RequireClaim(ClaimTypes.Role, EventCasePermissions.Employee.Delete);
    //        // Burada, politikanýn gereksinimlerini belirleyebilirsiniz.
    //        // Örneðin, belirli bir claim'e sahip olma gereksinimi gibi.
    //    });


});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:7274") // Ýzin verilen kaynak
                   .AllowAnyMethod() // Tüm HTTP metodlarýna izin ver
                   .AllowAnyHeader(); // Tüm baþlýklara izin ver

            builder.WithOrigins("https://localhost:7234") // Ýzin verilen kaynak
                   .AllowAnyMethod() // Tüm HTTP metodlarýna izin ver
                   .AllowAnyHeader(); // Tüm baþlýklara izin ver
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

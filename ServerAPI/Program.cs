using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Implementation;
using DataAccessLayer.IRepository;
using DataAccessLayer.Mapper;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NLog.Web;
using NLog;
using DataAccessLayer.Utility;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile("appsettings.json");

    //NLog: Setup NLog for Dependancy injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddAutoMapper(typeof(MapperProfile));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



    builder.Services.AddScoped<IEmployeeRepository>(_ => new EmployeeRepository(connectionString));
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();


    builder.Services.AddScoped<IAuthRepository>(_ => new AuthRepository(connectionString));
    builder.Services.AddScoped<IAuthService, AuthService>();


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "api/[controller]/login", Version = "v1" });
    });





    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseRouting();

    app.UseCors(builder => builder
        .WithOrigins("http://localhost:3000") // Replace with your URL
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex);
}
finally
{
    LogManager.Shutdown();
}
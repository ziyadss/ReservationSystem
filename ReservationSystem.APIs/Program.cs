using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReservationSystem.Data;
using ReservationSystem.Data.Users;
using ReservationSystem.DataStructures.Authentication;
using ReservationSystem.Repositories;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReservationSystem.APIs;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ReservationSystemDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services
            .AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = false;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ReservationSystemDbContext>();

        var jwtSection = builder.Configuration.GetRequiredSection("JwtTokenSettings");
        var jwtSettings = jwtSection.Get<JwtTokenSettings>() ?? throw new InvalidOperationException("JwtTokenSettings not found.");
        builder.Services.AddSingleton(jwtSettings);

        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtSettings.KeyBytes),
                    ClockSkew = TimeSpan.Zero
                };
            });

        builder.Services.AddScoped<IMatchRepository, MatchRepository>();
        builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services
            .AddSwaggerGen(options =>
            {
                var openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = $"JWT Authorization header using the Bearer scheme.{Environment.NewLine}Enter 'Bearer' [space] and then your token in the text input below.{Environment.NewLine}Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };
                options.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                var openApiSecurityRequirement = new OpenApiSecurityRequirement
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
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                };
                options.AddSecurityRequirement(openApiSecurityRequirement);

                var xmlFiles = Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (var xmlFile in xmlFiles)
                {
                    options.IncludeXmlComments(xmlFile);
                }
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

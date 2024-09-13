// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using Clean.Api.Middleware;
using Clean.Application;
using Clean.Persistence;
using Microsoft.OpenApi.Models;

namespace Clean.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigurePipeline(this WebApplication application)
        {
            if (application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean API Example");
                });
            }

            application.UseHttpsRedirection();

            // TODO: enable authentication
            //application.UseAuthentication();

            application.UseCustomExceptionHandler();
            application.UseCors();

            // TODO: enable authorization
            //application.UseAuthorization();

            application.MapControllers();

            return application;
        }

        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();

            // TODO: add builder.Services.AddInfrastructureServices(builder.Configuration); if using

            builder.Services.AddPersistenceServices(builder.Configuration);

            // TODO: add builder.Services.AddIdentityServices(builder.Configuration); if using

            // TODO: add builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>(); if using

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                // TODO: drop if not using JWT
                //s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                //      Enter 'Bearer' [space] and then your token in the text input below.
                //      \r\n\r\nExample: 'Bearer 12345abcdef'",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});

                //s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //    }
                //});

                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean API Example"
                });
            });
        }
    }
}

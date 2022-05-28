using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Factories;
using Dislinkt.Profile.Persistance.MongoDB.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MediatR;
using Dislinkt.Profile.App.RegisterUser.Commands;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Dislinkt.Profile.Core.MessageProducers;
using Dislinkt.Profile.RabbitMQ.MessageProducers;
using Dislinkt.Profile.Core.Services;
using Dislinkt.Profile.App.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Dislinkt.Profile
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            services.AddMvcCore();
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Profile API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddAuthentication()
                    .AddJwtBearer(cfg =>
                    {
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false

                        };
                    });


            services.Configure<MongoSettings>(options =>
            {
                options.Connection = Configuration.GetSection("MongoSettings:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MongoSettings:DatabaseName").Value;
            });

            services.AddSingleton(Configuration);
            services.AddMediatR(typeof(RegisterUserCommand).GetTypeInfo().Assembly);
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<MongoDbContext>();
            services.AddScoped<IMessageProducer, MessageProducer>();

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Profile API V1");
                });

            }
            // Shows UseCors with CorsPolicyBuilder.
           

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();

            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
           // {
           //     Audience = "http://localhost:5001/",
           //     Authority = "http://localhost:5000/"
           // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

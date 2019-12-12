using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace BancoDeDadosTw {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        //para habilitar o cors
        readonly string PermissaoEntreOrigens = "_PermissaoEntreOrigens";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                // Mostrar o caminho dos comentários dos métodos Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine (AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments (xmlPath);
            });

            //services.AddControllers();
            services.AddControllersWithViews ().AddNewtonsoftJson (opt => {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true, //Habilita a validadção do Issuer do token
                    ValidateAudience = true, //Habilita a valudação do Audience do token
                    ValidateLifetime = true, //Habilita a validação do Tempo de expiração do token
                    ValidateIssuerSigningKey = true, //Permite que a microsoft valide o token
                    ValidIssuer = Configuration["Jwt:Issuer"], //Define um valor válido para um issuer
                    ValidAudience = Configuration["Jwt:Issuer"], // Define um valor válido para o Audience
                    // Issuer Signing Key será igual resultado de SymmetricSecurityKey recebendo a JWT key criptografada
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration["Jwt:Key"]))
                    };
                });

            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseCors (builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            app.UseAuthentication ();
            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
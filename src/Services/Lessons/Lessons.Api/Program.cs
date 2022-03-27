global using FastEndpoints;
global using FastEndpoints.Validation;
global using Lessons.Api.Models;
using FastEndpoints.Swagger;
using Lessons.Api.Infrastructure.Data;
using Lessons.Api.Infrastructure.Repositories;
using Lessons.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LessonsApiContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<ILessonsRepository, LessonsRepository>();
builder.Services.AddScoped<IAlternativesRepository, AlternativesRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddSwaggerDoc();
builder.Services.AddFastEndpoints();

// var root = Directory.GetCurrentDirectory();
// var dotenv = Path.Combine(root, ".env");
// EnvService.Load(dotenv);

// string key = Environment.GetEnvironmentVariable("SECRET_KEY");

// builder.Services.AddAuthentication(x => 
//     {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(x => 
//     {
//         x.RequireHttpsMetadata = false;
//         x.SaveToken = true;
//         x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };   
//     });

// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
//   {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking API", Version = "v1" });
//     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//       {
//         Description = @"JWT Authorization header using the Bearer scheme.  
//                       Enter 'Bearer' [space] and then your login token in the text input below.
//                       Example: 'Bearer 12345abcdef'",
//          Name = "Authorization",
//          In = ParameterLocation.Header,
//          Type = SecuritySchemeType.ApiKey,
//          Scheme = "Bearer"
//        });

//     c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//       {
//         {
//           new OpenApiSecurityScheme
//           {
//             Reference = new OpenApiReference
//               {
//                 Type = ReferenceType.SecurityScheme,
//                 Id = "Bearer"
//               },
//               Scheme = "oauth2",
//               Name = "Bearer",
//               In = ParameterLocation.Header,

//             },
//             new List<string>()
//           }
//         });
//     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//     c.IncludeXmlComments(xmlPath);
// });


var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();
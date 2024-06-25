using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend.Donation.Application.Internal.CommandServices;
using Backend.Donation.Application.Internal.QueryServices;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Donation.Infraestructure.Persistence.EFC.Repositories;
using Backend.Exchange.Application.Internal.CommandServices;
using Backend.Exchange.Application.Internal.QueryServices;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;
using Backend.IAM.Application.Internal.CommandServices;
using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Application.Internal.QueryServices;
using Backend.IAM.Domain.Repositories;
using Backend.IAM.Domain.Services;
using Backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using Backend.IAM.Infrastructure.Persistence.EFC.Repositories;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using Backend.IAM.Infrastructure.Tokens.JWT.Services;
using Backend.IAM.Interfaces.ACL;
using Backend.IAM.Interfaces.ACL.Services;
using Backend.Profiles.Application.Internal.CommandServices;
using Backend.Profiles.Application.Internal.QueryServices;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;
using Backend.Profiles.Infrastructure.Persistence.EFC.Repositories;
using Backend.Profiles.Interfaces.ACL;
using Backend.Profiles.Interfaces.ACL.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Interfaces.ASP.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Techzo.CambiaZo.API",
                Version = "v1",
                Description = "TechZo CambiaZo Platform API",
                TermsOfService = new Uri("https://techzo-cambiazo.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "TechZo CambiaZo",
                    Email = "contact@techzo.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();


builder.Services.AddScoped<IOngRepository, OngRepository>();
builder.Services.AddScoped<IOngCommandService, OngCommandService>();
builder.Services.AddScoped<IOngQueryService, OngQueryService>();

builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

builder.Services.AddScoped<IProjectCommandService, ProjectCommandService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IAccountNumberRepository, AccountNumberRepository>();
builder.Services.AddScoped<IAccountNumberCommandService, AccountNumberCommandService>();

builder.Services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
builder.Services.AddScoped<ISocialNetworkCommandService, SocialNetworkCommandService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryCommandService, ProductCategoryCommandService>();
builder.Services.AddScoped<IProductCategoryQueryService, ProductCategoryQueryService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryCommandService, CountryCommandService>();
builder.Services.AddScoped<ICountryQueryService, CountryQueryService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentCommandService, DepartmentCommandService>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictCommandService, DistrictCommandService>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferCommandService, OfferCommandService>();
builder.Services.AddScoped<IOfferQueryService, OfferQueryService>();

builder.Services.AddScoped<IBenefitRepository, BenefitRepository>();
builder.Services.AddScoped<IBenefitCommandService, BenefitCommandService>();

builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipCommandService, MembershipCommandService>();
builder.Services.AddScoped<IMembershipQueryService, MembershipQueryService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();



var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseRouting();

app.UseRequestAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
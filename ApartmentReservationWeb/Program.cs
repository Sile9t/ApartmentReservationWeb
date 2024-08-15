using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Mapper;
using ApartmentReservationWeb.RSATools;
using ApartmentReservationWeb.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var dbConnect = builder.Configuration["ConnectionStrings:db"];

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please anter token",
        Name = "Autorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "Token",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string []{ }
        }
    });
});
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMemoryCache(x => x.TrackStatistics = true);

builder.Services.AddDbContext<OccupancyContext>(options => options.UseSqlServer(
    dbConnect).UseLazyLoadingProxies().LogTo(Console.WriteLine));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserService>();

builder.Services.AddTransient<IApartmentRepository, ApartmentRepository>();
builder.Services.AddTransient<ApartmentService>();

builder.Services.AddTransient<IDateRepository, DateRepository>();
builder.Services.AddTransient<DateService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new RsaSecurityKey(RSAExtensions.GetPublicKey())
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (true)
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseRouting();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Login}/{id?}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

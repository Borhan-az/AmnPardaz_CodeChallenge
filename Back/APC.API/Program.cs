using APC.Application.Common.Interfaces;
using APC.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("APC.Application")));
builder.Services.TryAddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opt =>
{
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(builder.Configuration["secretkey"])),
    };

});
builder.Services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationDbContext>());

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("APC_DB"));
builder.Services.AddAuthorization(opt =>
{
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APC.API", Version = "v1" });
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
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

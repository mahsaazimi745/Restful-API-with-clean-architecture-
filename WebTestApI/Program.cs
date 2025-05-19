using WebTestApI.CoreLayer.Interface;
using WebTestApI.InfrastructureLayer.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebTestApI.ApplicationLayer.Interface;
using WebTestApI.ApplicationLayer.Services;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.InfrastructureLayer.Serialization.Converters;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<NationalCode>());
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<PhoneNumber>());
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<Email>());
            options.JsonSerializerOptions.Converters.Add(new PasswordJsonConverter());
        }
    });

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers();

    /*.AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<NationalCode>());
        options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<Email>());
        options.JsonSerializerOptions.Converters.Add(new PasswordJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<PhoneNumber>());
        
    });*/
   

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddInfrastructure(configuration);
//builder.Services.AddScoped<IUserRepository, UserRepository>();
/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultttt")));*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
/*if (app.Environment.IsDevelopment())
{
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<NationalCode>());
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<PhoneNumber>());
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<Email>());
            options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverter<Password>());
        });
}
else
{
    builder.Services.AddControllers(); // ���� �������
}*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

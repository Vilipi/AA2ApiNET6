using AA2ApiNet6.Mapper;
using AA2ApiNET6._1_Presentation.Handler;
using AA2ApiNET6._1_Presentation.Mapper;
using AA2ApiNET6._2_Domain.Infrastructure.Contracts.Contracts;
using AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Contracts;
using AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Impl;
using AA2ApiNET6._2_Domain.ServiceLibrary.Impl.Mapper;
using AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Data;
using AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Database;
using AA2ApiNET6._3_Infrastructure.Infrastructure.Impl.Impl;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataBaseService, DataBaseService>();

builder.Services.AddScoped<ISpecialistRepository, SpecialistRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<ISpecialistService, SpecialistService>();
builder.Services.AddScoped<IPatientService, PatientService>();
//Mappers
builder.Services.AddScoped<ISpecialistInputToDto, SpecialistInputToDto>();
builder.Services.AddScoped<IPatientInputToDto, PatientInputToDto>();
builder.Services.AddScoped<ISpecialistRepositoryModelToDto, SpecialistRepositoryModelToDto>();
builder.Services.AddScoped<IPatientRepositoryModelToDto, PatientRepositoryModelToDto>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AUTH
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

//SQL
builder.Services.AddDbContext<DataContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// NLOG
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication(); // AUTH

app.UseAuthorization();

app.MapControllers();

app.Run();

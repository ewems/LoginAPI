using LoginAPI.Application.Cadastro;
using LoginAPI.Application.Login;
using LoginAPI.Domains.Cadastro;
using LoginAPI.Domains.Login;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<ICadastroApplication, CadastroApplication>();
builder.Services.AddTransient<ICadastroDomain, CadastroDomain>();

builder.Services.AddTransient<ILoginApplication, LoginApplication>();
builder.Services.AddTransient<ILoginDomain, LoginDomain>();

builder.Services.AddSwaggerGen();

/*
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {

    }
    );

});*/


var app = builder.Build();

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

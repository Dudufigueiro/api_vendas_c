using System;
using APIVendas.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APIVendas.Services;
using APIVendas.BaseDados.Models;

namespace APIVendas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlSerializerFormatters();
            builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));
            builder.Services.AddScoped<CategoriasService>();
            builder.Services.AddScoped<ProdutosServices>();
            builder.Services.AddScoped<PessoasServices>();
            builder.Services.AddScoped<ClientesServices>();
            builder.Services.AddScoped<FuncionariosServices>();
            builder.Services.AddSingleton<ApiDbContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using VCA.Repositories;
using VCA.Services.AlternateComponent;
using VCA.Services.Invoices;
using VCA.Services.Manufaturers;
using VCA.Services.Registrations;
using VCA.Services.Segments;
using VCA.Services.Vehical;
using VCA.Services.Verient;

namespace VCA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<ISegmentService, SegmentServiceImpl>();
            builder.Services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            builder.Services.AddTransient<IModelRepository, ModelRepository>();
            builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            builder.Services.AddTransient<IComponentRepository, ComponentRepository>();
            builder.Services.AddTransient<IAlternateComponentRepository, AlternateComponentRepository>();
            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
            builder.Services.AddDbContext<AppDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("VcaDBConnection")));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      // builder.WithOrigins("http://127.0.0.1:5500")
                                      builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyAllowSpecificOrigins");

            app.MapControllers();

            app.Run();
        }
    }
}
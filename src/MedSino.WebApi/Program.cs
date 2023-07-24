
using MedSino.DataAccess.Interfaces.Bookings;
using MedSino.DataAccess.Interfaces.Categories;
using MedSino.DataAccess.Interfaces.Doctors;
using MedSino.DataAccess.Interfaces.Hospitals;
using MedSino.DataAccess.Interfaces.Raitings;
using MedSino.DataAccess.Interfaces.Users;
using MedSino.DataAccess.Repositories.Bookings;
using MedSino.DataAccess.Repositories.Categories;
using MedSino.DataAccess.Repositories.Doctors;
using MedSino.DataAccess.Repositories.Hospitals;
using MedSino.DataAccess.Repositories.Raitings;
using MedSino.DataAccess.Repositories.Users;
using MedSino.Service.Interfaces.Auth;
using MedSino.Service.Interfaces.Bookings;
using MedSino.Service.Interfaces.Categories;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Doctors;
using MedSino.Service.Interfaces.Hospitals;
using MedSino.Service.Interfaces.Notification;
using MedSino.Service.Interfaces.Raitings;
using MedSino.Service.Services.Auth;
using MedSino.Service.Services.Bookings;
using MedSino.Service.Services.Categories;
using MedSino.Service.Services.Common;
using MedSino.Service.Services.Doctors;
using MedSino.Service.Services.Hospitals;
using MedSino.Service.Services.Notification;
using MedSino.Service.Services.Raitings;

namespace MedSino.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMemoryCache();

            //->
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IRaitingRepository, RaitingRepository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IRaitingService, RaitingService>();

            builder.Services.AddScoped<ISmsSender, SmsSender>();
            //->

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
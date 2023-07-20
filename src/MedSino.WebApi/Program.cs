
using MedSino.DataAccess.Interfaces.Categories;
using MedSino.DataAccess.Interfaces.Hospitals;
using MedSino.DataAccess.Interfaces.Users;
using MedSino.DataAccess.Repositories.Categories;
using MedSino.DataAccess.Repositories.Hospitals;
using MedSino.DataAccess.Repositories.Users;
using MedSino.Service.Interfaces.Auth;
using MedSino.Service.Interfaces.Categories;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Hospitals;
using MedSino.Service.Interfaces.Notification;
using MedSino.Service.Services.Auth;
using MedSino.Service.Services.Categories;
using MedSino.Service.Services.Common;
using MedSino.Service.Services.Hospitals;
using MedSino.Service.Services.Notification;

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

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
using MedSino.Service.Interfaces.Auth;
using MedSino.Service.Interfaces.Bookings;
using MedSino.Service.Interfaces.Categories;
using MedSino.Service.Interfaces.Common;
using MedSino.Service.Interfaces.Doctors;
using MedSino.Service.Interfaces.Hospitals;
using MedSino.Service.Interfaces.Notification;
using MedSino.Service.Interfaces.Raitings;
using MedSino.Service.Interfaces.Users;
using MedSino.Service.Services.Auth;
using MedSino.Service.Services.Bookings;
using MedSino.Service.Services.Categories;
using MedSino.Service.Services.Common;
using MedSino.Service.Services.Doctors;
using MedSino.Service.Services.Hospitals;
using MedSino.Service.Services.Notification;
using MedSino.Service.Services.Raitings;
using MedSino.Service.Services.Users;

namespace MedSino.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IHospitalService, HospitalService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IRaitingService, RaitingService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
    }
}

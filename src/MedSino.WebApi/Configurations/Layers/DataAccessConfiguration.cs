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

namespace MedSino.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
        builder.Services.AddScoped<IRaitingRepository, RaitingRepository>();
    }
}

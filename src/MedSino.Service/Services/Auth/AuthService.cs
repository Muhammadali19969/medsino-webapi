using MedSino.DataAccess.Interfaces.Users;
using MedSino.Domain.Exceptions.Users;
using MedSino.Service.Common.Helpers;
using MedSino.Service.Dtos.Auth;
using MedSino.Service.Dtos.Security;
using MedSino.Service.Interfaces.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace MedSino.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;

    public AuthService(IMemoryCache memoryCache,
        IUserRepository userRepository)
    {
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
    }

    # pragma warning disable
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto registerDto)
    {
        var result = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (result is not null) throw new UserAlreadyExistsException(registerDto.Email);

        // delete if exists user by this email
        if (_memoryCache.TryGetValue(registerDto.Email, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(registerDto.Email);
        }
        else _memoryCache.Set(registerDto.Email, registerDto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email)
    {
        if (_memoryCache.TryGetValue(email, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();
            // make confirm code as random
            verificationDto.Code = 11111;
            _memoryCache.Set(email, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            // sms sender::begin
            // sms sender::end

            return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
        }
        else throw new UserCacheDataExpiredException();
    }

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new NotImplementedException();
    }
}

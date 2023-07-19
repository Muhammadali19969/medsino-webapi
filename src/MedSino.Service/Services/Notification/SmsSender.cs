using MedSino.Service.Dtos.Notifications;
using MedSino.Service.Interfaces.Notification;

namespace MedSino.Service.Services.Notification;

public class SmsSender : ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage)
    {
        throw new NotImplementedException();
    }
}

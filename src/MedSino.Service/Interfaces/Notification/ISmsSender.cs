using MedSino.Service.Dtos.Notifications;

namespace MedSino.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
    
}

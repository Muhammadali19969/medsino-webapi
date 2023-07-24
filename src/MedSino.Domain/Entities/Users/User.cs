using MedSino.Domain.Enums;

namespace MedSino.Domain.Entities.Users;

public sealed class User : Human
{
    public IdentityRole IdentityRole { get; set; }
}

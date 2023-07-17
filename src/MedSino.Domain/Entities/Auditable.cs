namespace MedSino.Domain.Entities;

public abstract class Auditable : BaseEntitiy
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

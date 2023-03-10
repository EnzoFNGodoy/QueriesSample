using Flunt.Notifications;

namespace QueriesSample.Domain.Core.Entities;

public abstract class Entity<T> : Notifiable<Notification> where T : class
{
    protected Entity()
    { }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.Now.ToUniversalTime();
    public DateTime UpdatedAt { get; protected set; } = DateTime.Now.ToUniversalTime();
    public EStatus Status { get; protected set; } = EStatus.Active;

    public void Update(DateTime createdAt)
        => CreatedAt = createdAt;

    public virtual void Activate()
    {
        if (IsValid)
            Status = EStatus.Active;
    }

    public virtual void Deactivate()
    {
        if (IsValid)
            Status = EStatus.Inactive;
    }
}

public enum EStatus
{
    Inactive = 0,
    Active = 1
}
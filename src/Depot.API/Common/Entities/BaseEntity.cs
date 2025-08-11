namespace Depot.API.Common.Entities;

public abstract class BaseEntity(DateTime createdAt, DateTime? updatedAt)
{
    public Guid Id { get; } 
    public DateTime CreatedAt { get; protected set; } = createdAt;
    public DateTime? UpdatedAt { get; protected set; } = updatedAt;

    public virtual void AddUpdatedDate(DateTime updatedAt)
        => UpdatedAt = updatedAt;
}

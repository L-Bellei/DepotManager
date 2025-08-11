namespace Depot.API.Common.Entities;

public abstract class BaseNamedEntity(DateTime createdAt, DateTime? updatedAt, string name, string description) 
    : BaseEntity(createdAt, updatedAt)
{
    public string Name { get; protected set; } = name;
    public string Description { get; protected set; } = description;

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDescription(string description)
        => Description = description;

}

namespace Depot.API.Common.Entities;

public sealed class Sector(DateTime createdAt, DateTime? updatedAt, string name, string description, Guid? responsibleEmployee = null)
    : BaseNamedEntity(createdAt, updatedAt, name, description)
{
    public Guid? ResponsibleEmployee { get; private set; } = responsibleEmployee;
    public Employee? Responsible { get; private set; }
    public ICollection<Employee> Employees { get; } = [];
    public ICollection<Enterprise> Enterprises { get; } = [];
    public ICollection<Product> Products { get; } = [];

    public void ChangeResponsibleEmployee(Guid responsibleEmployee)
        => ResponsibleEmployee = responsibleEmployee;
}

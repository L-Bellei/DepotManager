
namespace Depot.API.Common.Entities;

public sealed class Employee(string name, Guid sectorId, int age, DateTime dateOfBirth, 
    DateTime createdAt, DateTime? updatedAt) : BaseEntity(createdAt, updatedAt)
{
    public string Name { get; private set; } = name;
    public int Age { get; private set; } = age;
    public DateTime DateOfBirth { get; private set; } = dateOfBirth;
    public Guid SectorId { get; private set; } = sectorId;
    public Sector Sector { get; private set; } = null!;
    public void ChangeName(string  name)
        => Name = name;

    public void ChangeAge(int age)
        => Age = age;

    public void ChangeSector(Guid sectorId)
        => SectorId = sectorId;
}

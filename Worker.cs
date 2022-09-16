using System.Reflection;

namespace PayrolSystem;

public abstract class Worker
{
    public Worker(string fullName, Gender gender)
    {
        if (fullName.Length == 0)
        {
            throw new InvalidDataException(
                "Invalid 'fullName' argument. The length must be non-zero");
        }
        FullName = fullName;
        Description = gender;
    }

    public abstract string FullName { get; init; }
    public abstract Gender Description { get; init; }
    public abstract void Work(int goodsSold);
    public abstract int calculateWage();

}

using System.Reflection;

namespace PayrolSystem;

public abstract class Worker
{
    public enum Gender : byte
    {
        Male = 1,
        Female
    }

    public Worker(string? fullName, Gender gender)
    {
        if (fullName.Length == 0)
            throw new ArgumentException("Invalid 'fullName' argument. The length must be non-zero. Try again.\n");

        FullName = fullName;
        Description = gender;
    }

    public string? FullName { get; init; }
    public Gender Description { get; init; }
    public abstract void Work(int goodsSold);
    public abstract int CalculateWage();
}
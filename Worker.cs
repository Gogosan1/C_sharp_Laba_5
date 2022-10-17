using System.Reflection;

namespace PayrolSystem;

public abstract class Worker
{
    public enum Gender : byte
    {
        Male = 1,
        Female
    }

    public Worker(ref string fullName, Gender gender)
    {
        if (fullName.Length == 0)
            throw new ArgumentException("Invalid 'fullName' argument. The length must be non-zero. Try again.\n");

        FullName = fullName;
        Description = gender;
    }

    public abstract string FullName { get; init; }
    public abstract Gender Description { get; init; }
    public abstract void Work(int goodsSold);
    public abstract int CalculateWage();
}
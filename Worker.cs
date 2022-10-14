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
        FullName = fullName;
        Description = gender;
    }

    public abstract string FullName { get; init; }
    public abstract Gender Description { get; init; }
    public abstract void Work(int goodsSold);
    public abstract int CalculateWage();
}
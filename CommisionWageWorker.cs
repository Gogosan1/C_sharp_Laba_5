using PayrolSystem;

namespace C_sharp_laba_5;

public class CommissionWageWorker : Worker
{
    public int Salary { get; init; }
    public int Percentage { get; init; }

    public CommissionWageWorker(string _fullName, Gender _gender, int _salary, int _percentage)
        : base(_fullName, _gender) 
    {
        if (_salary <= 0)
            throw new ArgumentException("Invalid 'Salary' argument. Salary must be positive number.\n");

        if (_percentage <= 0 && _percentage > 100)
            throw new ArgumentException("Invalid 'percentage' argument." +
                                            "Value must be greater than zero and less than 100.\n");

        Salary = _salary;
        Percentage = _percentage;
        goodsSoldSum = 0;
    }

    public override void Work(int goodsSold)
    {
        goodsSoldSum += goodsSold;
    }

    public override int CalculateWage()
    {
        var wage = 0;
        var addition = (int)((float)goodsSoldSum * (float)Percentage / 100);

        if (addition != 0)
            wage = Salary + addition;

        goodsSoldSum = 0;

        return wage;
    }
    
    private static int goodsSoldSum;

}
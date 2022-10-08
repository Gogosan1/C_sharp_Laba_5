using PayrolSystem;
namespace C_sharp_laba_5;

public class CommissionWageWorker : Worker
{
    //private static readonly int locationSalary;
    // private static readonly int locationPercentage;
    private static int goodsSoldSum;
    // конструктор
    public CommissionWageWorker(string _fullName, Gender _gender, int _salary, int _percentage)
        : base(_fullName, _gender)
    {
        //исключения поправить    


        Salary = _salary;
        Percentage = _percentage;
        goodsSoldSum = 0;
    }

    //методы
    public override void Work(int goodsSold)
    {
        goodsSoldSum += goodsSold;
    }

    public override int calculateWage()
    {
        int wage = 0;
        int addition = (int)((float)goodsSoldSum * (float)(Percentage) / 100);

        if (addition != 0)
            wage = Salary + addition;

        goodsSoldSum = 0;

        return wage;
    }

    //свойства только для чтения
    public int Salary { get; init; }
    public int Percentage { get; init; }
    public override Gender Description { get; init; }
    public override string FullName { get; init; }

}

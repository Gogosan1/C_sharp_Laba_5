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

    public static CommissionWageWorker EnterCommissionWageWorker() 
    {
        Gender gender;
        string fullName;
        int salary, percentage;

        Console.WriteLine( "Enter fullname: ");
        fullName = Console.ReadLine();

        Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
        int intgender; 
        intgender = Console.Read(); // написать свой метод для считывания гендера

        if (intgender != 1 || intgender != 2)
        {
            throw new ArgumentException("Invalid value. Expected '1' or '2'\n");
        }
        if (intgender == 1)
            gender = Gender.Male;
        else
            gender = Gender.Female;

        Console.WriteLine( "Enter salary: ");
        salary = Console.Read();

        // if (Read.fail()) {
        //     throw new ArgumentException("Invalid value. Expected integer\n");
        // }

        Console.WriteLine( "Enter percentage: ");
        percentage = Console.Read();

        // if (Read.fail()) {
        //     throw new ArgumentException("Invalid value. Expected integer\n");
        // }

        CommissionWageWorker worker =
           new CommissionWageWorker(fullName, gender, salary, percentage);

        return worker;
    }
}

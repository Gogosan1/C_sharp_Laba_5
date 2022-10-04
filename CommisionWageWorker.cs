using Microsoft.VisualBasic;
using PayrolSystem;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

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
        if (Salary <= 0)
            throw new ArgumentOutOfRangeException("Invalid 'salary' argument. ",
                                                        "Value must be greater than zero");

        if (Percentage <= 0 && Percentage > 100)
            throw new ArgumentOutOfRangeException("Invalid 'percentage' argument. ",
                                                          "Value must be greater than zero and less than 100");

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

    public CommissionWageWorker enterCommissionWageWorker() {
        
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

        if (Read.fail()) {
            throw new ArgumentException("Invalid value. Expected integer\n");
        }

        Console.WriteLine( "Enter percentage: ");
        percentage = Console.Read();

        if (Read.fail()) {
            throw new ArgumentException("Invalid value. Expected integer\n");
        }

        CommissionWageWorker worker =
           new CommissionWageWorker(fullName, gender, salary, percentage);

        return worker;
    }
}
// перегруженный оператор вывода
/*std::ostream &operator<<(std::ostream &stream,
                         const CommissionWageWorker &worker) {
  stream << " {"
         << "\n   fullName: " << worker.FullName()
         << "\n   gender: " << worker.Gender()
         << "\n   salary: " << worker.Salary()
         << "\n   percentage: " << worker.Percentage() << "\n }";

  return stream;
}*/
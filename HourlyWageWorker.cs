using PayrolSystem;
namespace C_sharp_laba_5;


public class HourlyWageWorker : Worker
{
    private static int hoursWorked;
    private static int workedDays;
    public HourlyWageWorker(string _fullName, Gender _gender, int _normalHourlyWage, int _overtimeHourlyWage, int _standardOfWorkingHours) : base(_fullName, _gender)
    {
        if (_standardOfWorkingHours <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid 'standardOfWorkingHours' argument. ",

                "Value must be greater than zero.");
        }

        if (_standardOfWorkingHours > 24)
        {
            throw new ArgumentOutOfRangeException("Invalid 'standardOfWorkingHours' argument. ",

                "The value must be less than 24.");
        }

        if (_normalHourlyWage <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid 'normalHourlyWage' argument. ",

                                        "Value must be greater than zero.");

        }

        if (_overtimeHourlyWage <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid 'overtimeHourlyWage' argument. ",

                                        "Value must be greater than zero.");
        }

        int standardOfWorkingHours = _standardOfWorkingHours;
        normalHourlyWage = _normalHourlyWage;
        overtimeHourlyWage = _overtimeHourlyWage;
        hoursWorked = 0;
        workedDays = 0;
    }

    public override void Work(int hours)
    {
        hoursWorked += hours;
        workedDays++;
    }

    public override int calculateWage()
    {
        int normalHoursWorked = hoursWorked < standardOfWorkingHours * workedDays
                              ? hoursWorked
                              : standardOfWorkingHours * workedDays;
        int overtimeHoursWorked = hoursWorked - normalHoursWorked;

        hoursWorked = 0;
        workedDays = 0;

        return normalHoursWorked * normalHourlyWage +
               overtimeHoursWorked * overtimeHourlyWage;
    }

    //сделала свойства на твоем примере, но пока искала инфу, появилось много вопросов
    public override Gender Description { get; init; }
    public override string FullName { get; init; }
    public int normalHourlyWage { get; init; }
    public int overtimeHourlyWage { get; init; }
    public int standardOfWorkingHours { get; init; }

    public Worker EnterHourlyWageWorker()
    {
        Gender gender;
        int genderBuf;
        string fullName;
        int normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours;

        Console.WriteLine("Enter fullname: ");
        fullName = Console.ReadLine();

        Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
        genderBuf = Console.Read();

        if (genderBuf == 1)
        {
            gender = Gender.Male;
        }
        else
        {
            gender = Gender.Female;
        }

        if (gender != Gender.Male || gender != Gender.Female)
        {
            throw new ArgumentException("Invalid value. Expected '1' or '2'\n");
        }

        //тут криво и некрасиво, надо подумать
        Console.WriteLine("Enter normal hourly wage: ");
        normalHourlyWage = Console.Read();

        while (!int.TryParse(Console.ReadLine(), out normalHourlyWage))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter normal hourly wage: ");
            normalHourlyWage = Console.Read();
        }

        Console.WriteLine("Enter overtime wage: ");
        overtimeHourlyWage = Console.Read();

        while (!int.TryParse(Console.ReadLine(), out overtimeHourlyWage))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter overtime wage: ");
            overtimeHourlyWage = Console.Read();
        }


        Console.WriteLine("Enter standard of working hours: ");
        standardOfWorkingHours = Console.Read();

        while (!int.TryParse(Console.ReadLine(), out standardOfWorkingHours))
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter standard of working hours: ");
            standardOfWorkingHours = Console.Read();
        }

        HourlyWageWorker worker =
            new HourlyWageWorker(fullName, gender, normalHourlyWage, overtimeHourlyWage,
                             standardOfWorkingHours);

        return new HourlyWageWorker(fullName, gender, normalHourlyWage, overtimeHourlyWage,
                             standardOfWorkingHours);
    }
}

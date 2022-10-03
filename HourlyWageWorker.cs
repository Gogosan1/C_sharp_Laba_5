using System;
using System.Collections.Generic;
using System.Text;
using PayrolSystem;


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

    public Worker enterHourlyWageWorker()
    {
        Gender gender;
        string fullName;
        int normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours;

        Console.Write("Enter fullname: ");
        fullName = Console.ReadLine();

        Console.Write("Enter gender(1 - Male, 2 - Female): ");
        gender = Console.ReadLine();

        if (gender != Gender.Male || gender != Gender.Female)
        {
            throw new ArgumentException("Invalid value. Expected '1' or '2'\n");
        }

        //тут криво и некрасиво, надо подумать
        Console.Write("Enter normal hourly wage: ");
        normalHourlyWage = Convert.ToInt32(Console.ReadLine());

        while (!int.TryParse(Console.ReadLine(), out normalHourlyWage))
        {
            Console.Write("Invalid input!");
            Console.Write("Enter normal hourly wage: ");
            normalHourlyWage = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Enter overtime wage: ");
        overtimeHourlyWage = Convert.ToInt32(Console.ReadLine());

        while (!int.TryParse(Console.ReadLine(), out overtimeHourlyWage))
        {
            Console.Write("Invalid input!");
            Console.Write("Enter overtime wage: ");
            overtimeHourlyWage = Convert.ToInt32(Console.ReadLine());
        }


        Console.Write("Enter standard of working hours: ");
        standardOfWorkingHours = Convert.ToInt32(Console.ReadLine());

        while (!int.TryParse(Console.ReadLine(), out standardOfWorkingHours))
        {
            Console.Write("Invalid input!");
            Console.Write("Enter standard of working hours: ");
            standardOfWorkingHours = Convert.ToInt32(Console.ReadLine());
        }

        HourlyWageWorker worker =
            HourlyWageWorker(fullName, gender, normalHourlyWage, overtimeHourlyWage,
                             standardOfWorkingHours);
        return worker;
    }
}

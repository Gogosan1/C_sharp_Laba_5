using C_sharp_laba_5;
using PayrolSystem;
using System.Diagnostics;
using System.IO.Pipes;
using System.Reflection;
using static PayrolSystem.Worker;

public class Menu
{
    private static void Main(string[] args)
    {
        var menu = new Menu();
        menu.Listen();
    }


    public Menu()
    {
        company = new Company();
    }
    public static Worker EnterCommissionWageWorker()
    {
        Gender gender;
        string fullName;
        int salary, percentage;

        Console.WriteLine("Enter fullname: ");
        fullName = Console.ReadLine();

        Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
        int genderBuf = Convert.ToInt32(Console.ReadLine());

        if (genderBuf != 1 && genderBuf != 2)
            throw new ArgumentException("Invalid value. Expected '1' or '2'\n");

        if (genderBuf == 1)
            gender = Gender.Male;
        else
            gender = Gender.Female;

        Console.WriteLine("Enter salary: ");
        salary = Convert.ToInt32(Console.ReadLine());

        // if (Read.fail()) {
        //     throw new ArgumentException("Invalid value. Expected integer\n");
        // }

        Console.WriteLine("Enter percentage: ");
        percentage = Convert.ToInt32(Console.ReadLine());

        // if (Read.fail()) {
        //     throw new ArgumentException("Invalid value. Expected integer\n");
        // }
        Worker worker = new CommissionWageWorker(ref fullName, gender, salary, percentage);
        try
        {
           // Worker worker = new CommissionWageWorker(ref fullName, gender, salary, percentage);

        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);

        }
        return worker;
    }

    public static Worker EnterHourlyWageWorker()
    {
        Gender gender;
        string fullName;
        int normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours;

        Console.WriteLine("Enter fullname: ");
        fullName = Console.ReadLine();

        Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
        int genderBuf = Convert.ToInt32(Console.ReadLine());

        if (genderBuf != 1 && genderBuf != 2)
            throw new ArgumentException("Invalid value. Expected '1' or '2'\n");

        if (genderBuf == 1)
            gender = Gender.Male;
        else
            gender = Gender.Female;


        Console.WriteLine("Enter normal hourly wage: ");
        normalHourlyWage = Convert.ToInt32(Console.ReadLine());

        /*if (std::cin.fail())
        {
            throw std::invalid_argument("Invalid value. Expected integer\n");
        }*/

        Console.WriteLine("Enter overtime wage: ");
        overtimeHourlyWage = Convert.ToInt32(Console.ReadLine());

        /*if (std::cin.fail())
        {
            throw std::invalid_argument("Invalid value. Expected integer\n");
        }*/

        Console.WriteLine("Enter standard of working hours: ");
        standardOfWorkingHours = Convert.ToInt32(Console.ReadLine());

        /*if (std::cin.fail())
        {
            throw std::invalid_argument("Invalid value. Expected integer\n");
        }*/

        Worker worker = new HourlyWageWorker(ref fullName, gender, normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours);
        return worker;

    }

    private void HandleAddCommissionWageWorker()
    {
        try
        {
            var worker = EnterCommissionWageWorker();
            Console.Write("GGqqq");
            company.RecruitWorker(worker);
            Console.Write("Worker has been successfully recruited!\n");
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e.Message);
        }
    }

    private void HandleAddHourlyWageWorker()
    {
        try
        {
            var worker = EnterHourlyWageWorker();
            company.RecruitWorker(worker);
            Console.Write("Worker has been successfully recruited!\n");
        }
        catch (Exception e) // не выводит !!!!!
        {
            Debug.WriteLine("Exception: " + e.Message);
        }
    }

    private void HandleFireWorker()
    {
        var fullName = "";

        Console.Write("Enter the full name of worker to fire: ");
        fullName = Console.ReadLine();

        company.FireWorker(ref fullName);
        Console.Write("Worker has been successfully fired!\n");
    }

    private void HandlePrintWorkers()
    {
        Console.Write("Workers: ");
        List<Worker> workers = company.WorkerList;

        foreach (var person in workers)
            Console.Write(person.FullName + " ");
    }
    private void HandleSimulateWork()
    {
        int days;

        Console.Write("Enter number of working days: ");
        days = Convert.ToInt32(Console.ReadLine());

        // if (HandleError("Error! Invalid value. Expected unsigned integer\n"))
        //   return;

        Console.Write("Expenses: ");
        Console.Write(company.SimulateWork(days));
        Console.Write("\n");
        Console.Write("Worked days count: ");
        Console.Write(company.GetWorkedDaysCount());
        Console.Write("\n");
    }

    public void Listen()
    {

        while (true)
        {
            Console.Write("\n\tMenu options\n");
            Console.Write(ADD_HOURLY_WAGE_WORKER_OPTION);
            Console.Write("-Add hourly wage worker\n");
            Console.Write(ADD_COMMISSION_WAGE_WORKER_OPTION);
            Console.Write("-Add commission wage worker\n");
            Console.Write(FIRE_WORKER_BY_FULLNAME_OPTION);
            Console.Write("-Fire worker by full name\n");
            Console.Write(SIMULATE_WORK_OPTION);
            Console.Write("-Simulate work\n");
            Console.Write(PRINT_WORKERS_OPTION);
            Console.Write("-Print workers\n");
            Console.Write(EXIT_OPTION);
            Console.Write("-EXIT\n");
            Console.Write("\n");

            Console.Write("Enter option: ");

            int option;
            //Перед
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case ADD_HOURLY_WAGE_WORKER_OPTION:
                    HandleAddHourlyWageWorker();
                    break;
                case ADD_COMMISSION_WAGE_WORKER_OPTION:
                    HandleAddCommissionWageWorker();
                    break;
                case FIRE_WORKER_BY_FULLNAME_OPTION:
                    HandleFireWorker();
                    break;
                case SIMULATE_WORK_OPTION:
                    HandleSimulateWork();
                    break;
                case PRINT_WORKERS_OPTION:
                    HandlePrintWorkers();
                    break;
                case EXIT_OPTION:
                    return;
                default:
                    Console.WriteLine("Error! Undefined menu option\n");
                    break;
            }
        }
    }

    private readonly Company company;
    private const int ADD_HOURLY_WAGE_WORKER_OPTION = 1;
    private const int ADD_COMMISSION_WAGE_WORKER_OPTION = 2;
    private const int FIRE_WORKER_BY_FULLNAME_OPTION = 3;
    private const int SIMULATE_WORK_OPTION = 4;
    private const int PRINT_WORKERS_OPTION = 5;
    private const int EXIT_OPTION = 6;

}
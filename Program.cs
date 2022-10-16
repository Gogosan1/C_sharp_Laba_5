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
    public Worker EnterCommissionWageWorker()
    {
        Gender gender;
        string fullName;
        int salary, percentage;
       
        while (true)
        {
            Console.WriteLine("Enter fullname: ");
            fullName = Console.ReadLine();

            if (fullName.Length == 0)
                Console.Write("Invalid 'fullName' argument. The length must be non-zero. Try again.\n");
            else
            {
                if (company.CheckWorkerExist(ref fullName))
                    Console.Write("Worker with name " + fullName +
                                        " already recruited");
                else
                    break;
            }
        }

        while (true)
        {
            string genderBuf;

            while (true)
            {
                Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
                genderBuf = Console.ReadLine();
                try
                {
                    int gen = Convert.ToInt32(genderBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (Convert.ToInt32(genderBuf) != 1 && Convert.ToInt32(genderBuf) != 2)
                Console.Write("Invalid value. Expected '1' or '2'. Try again.\n");
            else
            {
                if (Convert.ToInt32(genderBuf) == 1)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
                break;
            }
        }

        while (true)
        {
            string salaryBuf;
            while (true)
            {
                Console.WriteLine("Enter salary: ");
                salaryBuf = Console.ReadLine();
                try
                {
                    salary = Convert.ToInt32(salaryBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (salary <= 0)
                Console.Write("Invalid 'Salary' argument. Salary must be positive number.\n");
            else
                break;
        }

        while (true)
        {
            string percentageBuf;
            while (true)
            {
                Console.WriteLine("Enter percentage: ");
                percentageBuf = Console.ReadLine();
                try
                {
                    percentage = Convert.ToInt32(percentageBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (percentage <= 0 && percentage > 100)
                Console.Write("Invalid 'percentage' argument." +
                                "Value must be greater than zero and less than 100.\ns");
            else
                break;
        }
      
        Worker worker = new CommissionWageWorker(ref fullName, gender, salary, percentage);

        return worker;
    }

    public Worker EnterHourlyWageWorker()
    {
        Gender gender;
        string fullName;
        int normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours;

        while (true)
        {
            Console.WriteLine("Enter fullname: ");
            fullName = Console.ReadLine();

            if (fullName.Length == 0)
                Console.Write("Invalid 'fullName' argument. The length must be non-zero. Try again.\n");
            else
            {
                if (company.CheckWorkerExist(ref fullName))
                    Console.Write("Worker with name " + fullName +
                                        " already recruited");
                else
                    break;
            }
        }

        while (true)
        {
            string genderBuf;

            while (true)
            {
                Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
                genderBuf = Console.ReadLine();
                try
                {
                    int gen = Convert.ToInt32(genderBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (Convert.ToInt32(genderBuf) != 1 && Convert.ToInt32(genderBuf) != 2)
                Console.Write("Invalid value. Expected '1' or '2'. Try again.\n");
            else
            {
                if (Convert.ToInt32(genderBuf) == 1)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
                break;
            }
        }

        while (true)
        {
            string normalHourlyWageBuf;
            while (true)
            {
                Console.WriteLine("Enter salary: ");
                normalHourlyWageBuf = Console.ReadLine();
                try
                {
                    normalHourlyWage = Convert.ToInt32(normalHourlyWageBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (normalHourlyWage <= 0)
                Console.Write("Invalid 'normalHourlyWage' argument. " +
                                                         "Value must be greater than zero. Try again.\n");
            else
                break;
        }

        while (true)
        {
            string overtimeHourlyWageBuf;
            while (true)
            {
                Console.WriteLine("Enter overtimeHourlyWage: ");
                overtimeHourlyWageBuf = Console.ReadLine();
                try
                {
                    overtimeHourlyWage = Convert.ToInt32(overtimeHourlyWageBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (overtimeHourlyWage <= 0)
                Console.Write("Invalid 'normalHourlyWage' argument. " +
                                                         "Value must be greater than zero. Try again.\n");
            else
                break;
        }

        while (true)
        {
            string standardOfWorkingHoursBuf;
            while (true)
            {
                Console.WriteLine("Enter standardOfWorkingHours: ");
                standardOfWorkingHoursBuf = Console.ReadLine();
                try
                {
                    standardOfWorkingHours = Convert.ToInt32(standardOfWorkingHoursBuf);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Exeption. Expected int value.\n");
                }
            }

            if (standardOfWorkingHours <= 0 || standardOfWorkingHours > 24)
                Console.Write("Invalid 'standardOfWorkingHours' argument. " +
                                                 "Value must be greater than zero and lower than 24. Try again.\n");
            else
                break;
        }
       
        Worker worker = new HourlyWageWorker(ref fullName, gender, normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours);
        return worker;
    }

    private void HandleAddCommissionWageWorker()
    {
        var worker = EnterCommissionWageWorker();

        company.RecruitWorker(worker);
        Console.Write("Worker has been successfully recruited!\n");

    }

    private void HandleAddHourlyWageWorker()
    {
        var worker = EnterHourlyWageWorker();
        company.RecruitWorker(worker);
        Console.Write("Worker has been successfully recruited!\n");
    }

    private void HandleFireWorker()
    {
        string fullName = "";

        while (true)
        {
            Console.Write("Enter the full name of worker to fire: ");
            fullName = Console.ReadLine();

            try
            {
                company.FireWorker(ref fullName);
                Console.Write("Worker has been successfully fired!\n");
                    break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        }
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
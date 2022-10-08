using System.Diagnostics;
using System.Runtime.InteropServices;
using PayrolSystem;

namespace C_sharp_laba_5;


public class Menu
{
    public extern HourlyWageWorker EnterHourlyWageWorker();
    public extern CommissionWageWorker EnterCommissionWageWorker();
    private Company company;
    private readonly uint ADD_HOURLY_WAGE_WORKER_OPTION = 1;
    private readonly uint ADD_COMMISSION_WAGE_WORKER_OPTION = 2;
    private readonly uint FIRE_WORKER_BY_FULLNAME_OPTION = 3;
    private readonly uint SIMULATE_WORK_OPTION = 4;
    private readonly uint PRINT_HOURLY_WAGE_WORKERS_OPTION = 5;
    private readonly uint PRINT_COMMISSION_WAGE_WORKERS_OPTION = 6;
    private readonly uint EXIT_OPTION = 7;

    public Menu()
    {
        company = new Company(); 
    }

    private void HandleAddHourlyWageWorker()
    {
        try
        {
            HourlyWageWorker worker = EnterHourlyWageWorker();
            company.RecruitHourlyWageWorker(worker);
            Console.Write("Worker has been successfully recruited!\n");
        }
        catch (System.Exception e)
        {
            Debug.WriteLine("Exception: " + e.Message);
        }
    }

    private void HandleAddCommissionWageWorker()
    {
        try
        {
            CommissionWageWorker worker = EnterCommissionWageWorker();
            company.RecruitCommissionWageWorker(worker);
            Console.Write("Worker has been successfully recruited!\n");
        }
        catch (System.Exception e)
        {
            Debug.WriteLine("Exception: " + e.Message);
        }
    }

    private void HandleFireWorkerByFullName()
    {
        var fullName = "";
        
        Console.Write("Enter the full name of worker to fire: ");
        Console.Read();
        fullName = Console.ReadLine();

        Company.Recruation status = company.GetRecruationStatus(fullName);

        if (status == Company.Recruation.None)
        {
            Console.Write("Error! Worker wasn't found\n");
            return;
        }

        if (status == Company.Recruation.Both)
        {
            Console.Write("Worker has been found in both groups.\n");
            Console.Write("Fire from(1 - Hourly, 2 - Commission, 3 - Both): ");
            int statusBuf = Console.Read();

            switch (statusBuf)
            {
                case 1:
                    status = Company.Recruation.Hourly;
                    break;
                case 2:
                    status = Company.Recruation.Commission;
                    break;
                case 3:
                    status = Company.Recruation.Both;
                    break;
                default:
                    Console.Write("Error! Invalid value. Expected '1' or '2' or '3'");
                    break;
            }
        }
        
        company.DismissWorkerByFullname(fullName, status);
        Console.Write("Worker has been successfully fired!\n");
    }

    private void HandlePrintHourlyWageWorkers()
    {
        Console.Write("Hourly wage workers: ");
        //Console.Write(company.GetHourlyWageWorkers());
    }
    private void HandlePrintCommissionWageWorkers()
    {
        Console.Write("Commission wage workers: ");
        //Console.Write(company.GetCommissionWageWorkers());
    }

    private void HandleSimulateWork()
    {
        int days;
        
        Console.Write("Enter number of working days: ");
        days = Console.Read();

        if (HandleError("Error! Invalid value. Expected unsigned integer\n"))
            return;
        
        Console.Write("Expenses: ");
        Console.Write(company.SimulateWork(days));
        Console.Write("\n");
        Console.Write("Worked days count: ");
        Console.Write(company.GetWorkedDaysCount());
        Console.Write("\n");
    }
    
    //доделать
    private bool HandleError(in string msg)
    {
        return true;
    }
    
    public void Listen()
  {

	// Тестовые данные

	company.RecruitHourlyWageWorker(new HourlyWageWorker("Petr Petrov", Worker.Gender.Male, 500, 700, 10));
	company.RecruitHourlyWageWorker(new HourlyWageWorker("Ivan Ivanov", Worker.Gender.Male, 700, 1000, 15));
	company.RecruitHourlyWageWorker(new HourlyWageWorker("Ekaterina Pavlovna", Worker.Gender.Female, 650, 850, 11));

	company.RecruitCommissionWageWorker(new CommissionWageWorker("Dmitry Dmitrievich", Worker.Gender.Male, 50000, 5));
	company.RecruitCommissionWageWorker(new CommissionWageWorker("Nataliya Adreevna", Worker.Gender.Female, 60500, 8));
	company.RecruitCommissionWageWorker(new CommissionWageWorker("Aleksandr Aleksandrovich", Worker.Gender.Male, 54400, 15));

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
	  Console.Write(PRINT_HOURLY_WAGE_WORKERS_OPTION);
	  Console.Write("-Print hourly wage workers\n");
	  Console.Write(PRINT_COMMISSION_WAGE_WORKERS_OPTION);
	  Console.Write("-Print commission wage workers\n");
	  Console.Write(EXIT_OPTION);
	  Console.Write("-EXIT\n");
	  Console.Write("\n");

	  Console.Write("Enter option: ");

	  uint option;
	  //Перед
	  option = ADD_HOURLY_WAGE_WORKER_OPTION;

	  if (HandleError("Error! Invalid value. Expected unsigned integer\n"))
	  {
		continue;
	  }

	  if (option == ADD_HOURLY_WAGE_WORKER_OPTION)
	  {
		HandleAddHourlyWageWorker();
		continue;
	  }

	  if (option == ADD_COMMISSION_WAGE_WORKER_OPTION)
	  {
		HandleAddCommissionWageWorker();
		continue;
	  }

	  if (option == FIRE_WORKER_BY_FULLNAME_OPTION)
	  {
		HandleFireWorkerByFullName();
		continue;
	  }

	  if (option == SIMULATE_WORK_OPTION)
	  {
		HandleSimulateWork();
		continue;
	  }

	  if (option == PRINT_HOURLY_WAGE_WORKERS_OPTION)
	  {
		HandlePrintHourlyWageWorkers();
		continue;
	  }

	  if (option == PRINT_COMMISSION_WAGE_WORKERS_OPTION)
	  {
		HandlePrintCommissionWageWorkers();
		continue;
	  }

	  if (option == EXIT_OPTION)
	  {
		return;
	  }

	  //std::cerr << "Error! Undefined menu option\n";
	}
  }

}


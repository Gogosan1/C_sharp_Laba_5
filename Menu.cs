using PayrolSystem;
using static PayrolSystem.Worker;

namespace C_sharp_laba_5
{
    public class Menu
    {
        private static void Main()
        {
            var menu = new Menu();
            menu.Listen();
        }


        public Menu()
        {
            company = new Company();
        }

        private static int GetCorrectInputConvertStringToInt(string? parametr)
        {
            try
            {
                int param = Convert.ToInt32(parametr);
                return param;
            }
            catch (FormatException)
            {
                throw new FormatException("Format Exeption. Expected int value.\n");
            }
        }

        /*    private static void CheckStringIsEmpty(string parametr)
            {
                try
                {
                i String.IsNullOrEmpty(parametr);
                }
                catch (FormatException)
                {
                    throw new FormatException("Format Exeption. Expected int value.\n");
                }
            }*/
        public static Worker EnterCommissionWageWorker()
        {

            Gender gender;
            string? fullName;
            int salary, percentage;

            Console.WriteLine("Enter fullname: ");
            fullName = Console.ReadLine();

            string? genderBuf;
            Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
            genderBuf = Console.ReadLine();
            int gen = GetCorrectInputConvertStringToInt(genderBuf);

            if (gen != 1 && gen != 2)
                throw new ArgumentException("Invalid value. Expected '1' or '2'. Try again.\n");
            else
            {
                if (gen == 1)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
            }


            string? salaryBuf;
            Console.WriteLine("Enter salary: ");
            salaryBuf = Console.ReadLine();
            salary = GetCorrectInputConvertStringToInt(salaryBuf);


            string? percentageBuf;
            Console.WriteLine("Enter percentage: ");
            percentageBuf = Console.ReadLine();
            percentage = GetCorrectInputConvertStringToInt(percentageBuf);

            Worker worker = new CommissionWageWorker(fullName, gender, salary, percentage);
            return worker;
        }

        public static Worker EnterHourlyWageWorker()
        {
            Gender gender;
            string? fullName;
            int normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours;

            Console.WriteLine("Enter fullname: ");
            fullName = Console.ReadLine();

            string? genderBuf;
            Console.WriteLine("Enter gender(1 - Male, 2 - Female): ");
            genderBuf = Console.ReadLine();

            int gen = GetCorrectInputConvertStringToInt(genderBuf);

            if (gen != 1 && gen != 2)
                throw new ArgumentException("Invalid value. Expected '1' or '2'. Try again.\n");
            else
            {
                if (gen == 1)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
            }

            string? normalHourlyWageBuf;
            Console.WriteLine("Enter salary: ");
            normalHourlyWageBuf = Console.ReadLine();
            normalHourlyWage = GetCorrectInputConvertStringToInt(normalHourlyWageBuf);

            string? overtimeHourlyWageBuf;
            Console.WriteLine("Enter overtimeHourlyWage: ");
            overtimeHourlyWageBuf = Console.ReadLine();
            overtimeHourlyWage = GetCorrectInputConvertStringToInt(overtimeHourlyWageBuf);

            string? standardOfWorkingHoursBuf;
            Console.WriteLine("Enter standardOfWorkingHours: ");
            standardOfWorkingHoursBuf = Console.ReadLine();
            standardOfWorkingHours = GetCorrectInputConvertStringToInt(standardOfWorkingHoursBuf);

            Worker worker = new HourlyWageWorker(fullName, gender, normalHourlyWage, overtimeHourlyWage, standardOfWorkingHours);
            return worker;
        }

        public void HandleAddCommissionWageWorker()
        {
            try
            {
                var worker = EnterCommissionWageWorker();

                company.RecruitWorker(worker);
                Console.Write("Worker has been successfully recruited!\n");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void HandleAddHourlyWageWorker()
        {
            try
            {
                var worker = EnterHourlyWageWorker();

                company.RecruitWorker(worker);
                Console.Write("Worker has been successfully recruited!\n");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void HandleFireWorker()
        {
            string? fullName;

            while (true)
            {
                Console.Write("Enter the full name of worker to fire: ");
                fullName = Console.ReadLine();

                try
                {
                    company.FireWorker(fullName);
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
            while (true)
            {
                string? daysBuf;


                Console.Write("Enter number of working days: ");
                daysBuf = Console.ReadLine();
                days = GetCorrectInputConvertStringToInt(daysBuf);
                
                if (days <= 0)
                    Console.WriteLine("Invalid 'Days' argument. Days must be positive number.\n");
                else
                    break;
                
            }

            Console.Write("Expenses: ");
            Console.Write(company.SimulateWork(days));
            Console.Write("\n");
            Console.Write("Worked days count: ");
            Console.Write(company.GetWorkedDaysCount());
            Console.Write("\n");
        }

        public void Listen()
        {
            int option;

            while (true)
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


                    string? optionBuf;

                    optionBuf = Console.ReadLine();
                    option = GetCorrectInputConvertStringToInt(optionBuf);

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
        }

        private readonly Company company;
        private const int ADD_HOURLY_WAGE_WORKER_OPTION = 1;
        private const int ADD_COMMISSION_WAGE_WORKER_OPTION = 2;
        private const int FIRE_WORKER_BY_FULLNAME_OPTION = 3;
        private const int SIMULATE_WORK_OPTION = 4;
        private const int PRINT_WORKERS_OPTION = 5;
        private const int EXIT_OPTION = 6;

    }
}
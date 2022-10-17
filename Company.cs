using PayrolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace C_sharp_laba_5;

public class Company
{
    public int GetWorkedDaysCount()
    {
        return workedDaysCount;
    }


    public Company()
    {
        WorkerList = new List<Worker>();
        workedDaysCount = 0;
    }

    //Найм сотрудника с почасовой оплатой
    public void RecruitWorker(Worker newWorker)
    {
        foreach (var worker in WorkerList)
            if ( String.Compare(worker.FullName, newWorker.FullName) == 0)
                throw new ArgumentException("Worker with name " + newWorker.FullName +
                                " already recruited");

                WorkerList.Add(newWorker);
    }

    //Увольнение сотрудника с почасовой оплатой
    public void FireWorker(ref string fullName)
    {
        foreach (var worker in WorkerList)
            if (fullName == worker.FullName)
            {
                WorkerList.Remove(worker);
                return;
            }
        throw new ArgumentException("Worker with name '" + fullName + "' wasn't found");
    }


    // Моделирование работы
    public int SimulateWork(int days)
    {
        int expenses = 0;
        var randomNumbers = new Random(Environment.TickCount);

        for (int workedDays = 0; workedDays < days; workedDays++)
        {
            foreach (var worker in WorkerList)
            {
                Worker workerReferense = worker;

                workerReferense.Work(randomNumbers.Next() % MAX_PRICE);
            }

            workedDaysCount++;

            if (workedDaysCount % WORKING_CYCLE == 0)
            {
                foreach (var worker in WorkerList)
                    expenses += worker.CalculateWage();
            }
        }

        workedDaysCount %= 15;

        return expenses;
    }

    public List<Worker> WorkerList { get; init; }
    private int workedDaysCount;
    private const int MAX_PRICE = 15000;
    private const int WORKING_CYCLE = 15;

}


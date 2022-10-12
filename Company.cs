namespace C_sharp_laba_5;

using System.Collections.Generic;

public class Company
{
    public enum Recruation : byte
    {
        Commission = 1,
        Hourly,
        Both,
        None
    }

    // попробовать инверсию зависимостей
    public Company()
    {
        CommissionWageWorkers = new List<CommissionWageWorker>();
        HourlyWageWorkers = new List<HourlyWageWorker>();
        WorkedDaysCount = 0;
    }

    public void RecruitHourlyWageWorker(ref HourlyWageWorker newWorker)
    {
        foreach (var i in HourlyWageWorkers)
            if (i.FullName == newWorker.FullName)
                throw new ArgumentException("Worker with name '" + newWorker.FullName + "' already recruited");
        HourlyWageWorkers.Add(newWorker);
    }

    public void RecruitCommissionWageWorker(ref CommissionWageWorker newWorker)
    {
        foreach (var i in CommissionWageWorkers)
            if (i.FullName == newWorker.FullName)
                throw new ArgumentException("Worker with name '" + newWorker.FullName + "' already recruited");
        CommissionWageWorkers.Add(newWorker);
    }

    private void DismissHourlyWageWorker(ref string fullName)
    {
        foreach (var i in HourlyWageWorkers)
            if (fullName == i.FullName)
                HourlyWageWorkers.Remove(i);
    }

    private void DismissCommissionWageWorker(ref string fullName)
    {
        foreach (var i in CommissionWageWorkers)
            if (fullName == i.FullName)
                CommissionWageWorkers.Remove(i);
    }

    public Recruation GetRecruationStatus(/*ref*/ string fullName) // подумай на счёт ссылки
    {
        var status = Recruation.None;

        foreach (var t in HourlyWageWorkers.Where(t => t.FullName == fullName)) status = Recruation.Hourly;

        foreach (var t in CommissionWageWorkers.Where(t => t.FullName == fullName))
            if (status == Recruation.Hourly)
                status = Recruation.Both;
            else
                status = Recruation.Commission;
        return status;
    }

    public int GetWorkedDaysCount()
    {
        return WorkedDaysCount;
    }

    /*
    Доделаю чуть позже, когда разберусь
     
    const std::vector<HourlyWageWorker> &Company::getHourlyWageWorkers() const {
        return hourlyWageWorkers;
    }

    const std::vector<CommissionWageWorker> &
    Company::getCommissionWageWorkers() const {
        return commissionWageWorkers;
    }
    */

    public void DismissWorkerByFullname(ref string fullName, Recruation status)
    {
        switch (status)
        {
            case Recruation.Both:
                DismissHourlyWageWorker(ref fullName);
                DismissCommissionWageWorker(ref fullName);
                break;
            case Recruation.Hourly:
                DismissHourlyWageWorker(ref fullName);
                break;
            case Recruation.Commission:
                DismissCommissionWageWorker(ref fullName);
                break;
            case Recruation.None:
                break;
        }
    }

    public int SimulateWork(int days)
    {
        var randomNumbers = new Random(Environment.TickCount);
        var expenses = 0;

        for (var workedDays = 0; workedDays < days; workedDays++)
        {
            foreach (var worker in HourlyWageWorkers)
            {
                var minWorkingHours = (int)worker.StandardOfWorkingHours;
                var maxWorkingHours = (int)(minWorkingHours + (24 - minWorkingHours) / 2);

                worker.Work(randomNumbers.Next() % maxWorkingHours);
            }

            foreach (var t in CommissionWageWorkers)
                t.Work(randomNumbers.Next() % MAX_PRICE);

            WorkedDaysCount++;

            if (WorkedDaysCount % WORKING_CYCLE != 0) continue;
            expenses += HourlyWageWorkers.Sum(t => (int)t.CalculateWage());
            expenses += CommissionWageWorkers.Sum(t => (int)t.CalculateWage());
        }

        WorkedDaysCount %= WORKING_CYCLE;

        return expenses;
    }

    private List<CommissionWageWorker> CommissionWageWorkers;
    private List<HourlyWageWorker> HourlyWageWorkers;
    private int WorkedDaysCount;

    private const int MAX_PRICE = 15000;
    private const int WORKING_CYCLE = 15;

}
using PayrolSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static PayrolSystem.Worker;
namespace C_sharp_laba_5;
public class HourlyWageWorker : Worker
{

    public override Gender Description { get; init; }
    public override string FullName { get; init; }
    public int NormalHourlyWage { get; init; }
    public int OvertimeHourlyWage { get; init; }
    public int StandardOfWorkingHours { get; init; }
    public HourlyWageWorker(ref string _fullName, Gender _gender, int _normalHourlyWage, int _overtimeHourlyWage, int _standardOfWorkingHours)
    : base(ref _fullName, _gender)
    {
        StandardOfWorkingHours = _standardOfWorkingHours;
        NormalHourlyWage = _normalHourlyWage;
        OvertimeHourlyWage = _overtimeHourlyWage;
        hoursWorked = 0;
        workedDays = 0;
    }

    public override void Work(int hours)
    {
        hoursWorked += hours;
        workedDays++;
    }

    public override int CalculateWage()
    {
        var normalHoursWorked = (hoursWorked < StandardOfWorkingHours * workedDays) ? hoursWorked : (StandardOfWorkingHours * workedDays);
        var overtimeHoursWorked = hoursWorked - normalHoursWorked;

        hoursWorked = 0;
        workedDays = 0;

        return normalHoursWorked * NormalHourlyWage + overtimeHoursWorked * OvertimeHourlyWage;
    }


    private int hoursWorked;
    private int workedDays;
}

﻿using PayrolSystem;
namespace C_sharp_laba_5;
public class HourlyWageWorker : Worker
{
    public int NormalHourlyWage { get; init; }
    public int OvertimeHourlyWage { get; init; }
    public int StandardOfWorkingHours { get; init; }
    public HourlyWageWorker(string _fullName, Gender _gender, int _normalHourlyWage, int _overtimeHourlyWage, int _standardOfWorkingHours)
    : base(_fullName, _gender)
    {

        if (_normalHourlyWage <= 0)
            throw new ArgumentException("Invalid 'normalHourlyWage' argument. " +
                                                     "Value must be greater than zero. Try again.\n");
        
        if (_overtimeHourlyWage <= 0)
            throw new ArgumentException("Invalid 'normalHourlyWage' argument. " +
                                                     "Value must be greater than zero. Try again.\n");

        if (_standardOfWorkingHours <= 0 || _standardOfWorkingHours > 24)
            throw new ArgumentException("Invalid 'standardOfWorkingHours' argument. " +
                                             "Value must be greater than zero and lower than 24. Try again.\n");

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

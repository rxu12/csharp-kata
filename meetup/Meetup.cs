using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    int _year;
    int _month;

    public Meetup(int month, int year)
    {
        _year = year;
        _month = month;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        return schedule == Schedule.Teenth ? CalcFirstWeekDayFrom(13, dayOfWeek)
            : CalcNthDate(dayOfWeek, schedule);
    }

    private DateTime CalcNthDate(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime firstWeekDayDate = CalcFirstWeekDayFrom(1, dayOfWeek);
        int week = (int)schedule - 1;
        DateTime dateByCalc = firstWeekDayDate.AddDays(week * 7);
        return dateByCalc.Month == _month ? dateByCalc : dateByCalc.AddDays(-7);
    }

    private DateTime CalcFirstWeekDayFrom(int date, DayOfWeek dayOfWeek)
    {
        int daysMore = 0;
        DayOfWeek dayOfWeekFrom = new DateTime(_year, _month, date).DayOfWeek;
        while (dayOfWeek != dayOfWeekFrom)
        {
            dayOfWeekFrom = (int)dayOfWeekFrom == 6 ? 0 : dayOfWeekFrom + 1;
            daysMore++;
        }
        return new DateTime(_year, _month, date + daysMore);
    }
}

/*
using System;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int _month { get; }
    private int _year { get; }

    public Meetup(int month, int year)
    {
        this._year = year;
        this._month = month;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var days = Enumerable
            .Range(1, DateTime.DaysInMonth(_year, _month))
            .Select(day => new DateTime(_year, _month, day))
            .Where(date => date.DayOfWeek == dayOfWeek)
            .ToList();

        switch (schedule)
        {
            case Schedule.First:
                return days[0];
            case Schedule.Second:
                return days[1];
            case Schedule.Third:
                return days[2];
            case Schedule.Fourth:
                return days[3];
            case Schedule.Last:
                return days.Last();
            case Schedule.Teenth:
                return days.First(date => date.Day > 12);
        }
        throw new ArgumentOutOfRangeException();
    }
}
 */
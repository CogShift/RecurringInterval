﻿using System;

namespace RecurringInterval
{
    internal class WeeklyInterval : Interval
    {
        public WeeklyInterval(DateTime startDate): this(startDate, ((int)startDate.DayOfWeek + 1) % 6)
        {
        }

        public WeeklyInterval(DateTime startDate, int endDay) : base(Period.Weekly)
        {
            EndDay = endDay;

            if ((int)startDate.DayOfWeek > endDay)
                EndDate = startDate.AddDays(7 - (int)startDate.DayOfWeek + endDay);
            else if ((int)startDate.DayOfWeek < endDay)
                EndDate = startDate.AddDays(endDay - (int)startDate.DayOfWeek);
            else
                EndDate = startDate;

            StartDate = EndDate.AddDays(-6);
        }

        public override Interval Next()
        {
            return new WeeklyInterval(NextStartDate(), EndDay);
        }

        private DateTime NextStartDate()
        {
            return EndDate.AddDays(1);
        }
        
    }
   
}
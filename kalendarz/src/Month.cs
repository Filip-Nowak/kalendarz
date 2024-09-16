using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalendarz.src
{
    internal class Month
    {
        public List<List<Day>> days;
        public Month(int month, int year)
        {
            DateTime date = new DateTime(year, month, 1);
            int weekDay= (int)date.DayOfWeek;
            if(month==1)
            {
                month = 13;
                year--;
            }
            int lastDayOfPreviousMonth = DateTime.DaysInMonth(year, month - 1);
            if (month == 13) month = 1;
            if(weekDay==0) weekDay = 7;
            List<Day> days = new List<Day>();
            for(int i=1;i<weekDay;i++)
            {
                days.Insert(0, new Day(lastDayOfPreviousMonth - i + 1, month - 1, year,true));
            }
            int index = 0;
            while(days.Count <= 7)
            {
                index++;
                days.Add(new Day(index, month, year));
            }
            this.days = new List<List<Day>>
            {
                days
            };
            days=new List<Day>();
            for(int i=index;i<=DateTime.DaysInMonth(year, month);i++)
            {
                days.Add(new Day(i, month, year));
                if(days.Count==7)
                {
                    this.days.Add(days);
                    days = new List<Day>();
                }
            }
            index = 1;
            if (days.Count > 0)
            {
                while (days.Count < 7)
                {
                    days.Add(new Day(index, month + 1, year,true));
                    index++;
                }
                this.days.Add(days);
            }
        }
    }
}

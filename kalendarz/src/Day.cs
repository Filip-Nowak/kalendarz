using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kalendarz.src
{
    public class Day
    {
        public int day { get; set; }
        public int month;
        public int year;
        public List<string> tasks = new List<string>();
        public bool disabled { get; } = false;
        public Day(int day, int month, int year)
        {
            Initialize(day, month, year);
        }
        public Day(int day, int month, int year, bool disabled)
        {
            this.Initialize(day, month, year);
            this.disabled = disabled;
        }

        private void Initialize(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            string[] tasks = TaskManager.GetTasks(day, month, year).ToArray();
            this.tasks=tasks.ToList();
        }
    }
}

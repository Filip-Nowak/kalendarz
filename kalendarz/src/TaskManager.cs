using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalendarz.src
{
    public class TaskManager
    {
        public static void AddTask(int day, int month, int year, string task)
        {
            string content = FileManager.ReadFromFile();
            content += day + "," + month + "," + year + "," + task + "\n";
            FileManager.SaveToFile(content);
        }

        public static void RemoveTask(int day, int month, int year, string task)
        {
            string content = FileManager.ReadFromFile().Trim();
            string[] tasks = content.Split('\n');
            content = "";
            for (int i = 0; i < tasks.Length; i++)
            {
                string[] taskData = tasks[i].Split(',');
                if (int.Parse(taskData[0]) == day && int.Parse(taskData[1]) == month && int.Parse(taskData[2]) == year && taskData[3] == task)
                {
                    continue;
                }
                content += tasks[i] + "\n";
            }
            FileManager.SaveToFile(content);
        }
        public static List<string> GetTasks(int day, int month, int year)
        {
            List<string> tasks = new List<string>();
            string content = FileManager.ReadFromFile().Trim();
            Console.WriteLine(content);
            string[] tasksData = content.Split('\n');
            for (int i = 0; i < tasksData.Length; i++)
            {
                string[] taskData = tasksData[i].Split(',');
                if(taskData.Length<4)
                {
                    continue;
                }
                if (int.Parse(taskData[0]) == day && int.Parse(taskData[1]) == month && int.Parse(taskData[2]) == year)
                {
                    tasks.Add(taskData[3]);
                }
            }
            Console.WriteLine(tasks);
            return tasks;
        }
    }
}

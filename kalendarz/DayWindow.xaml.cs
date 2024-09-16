using kalendarz.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kalendarz
{
    public partial class DayWindow : Window
    {
        public Day day;
        public DayWindow(Day day)
        {
            Console.WriteLine(day.tasks.Count);
            InitializeComponent();
            this.day = day;
            string monthName = new DateTime(2022, day.month, 1).ToString("MMMM");
            dayLabel.Content = day.day;
            monthLabel.Content = monthName+" "+day.year;
            tasks.ItemsSource = day.tasks;
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel panel=button.Parent as StackPanel;
            int index = panel.Children.IndexOf(button);
            string task = day.tasks[index-1];
            day.tasks.RemoveAt(index-1);
            TaskManager.RemoveTask(day.day, day.month, day.year, task);
            tasks.ItemsSource = null;
            tasks.ItemsSource = day.tasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow(day.day, day.month, day.year,this);
            addTaskWindow.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

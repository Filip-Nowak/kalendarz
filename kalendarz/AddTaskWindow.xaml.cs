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
    public partial class AddTaskWindow : Window
    {
        DayWindow dayWindow;
        public AddTaskWindow(DayWindow dayWindow) { 
            this.dayWindow = dayWindow;
            InitializeComponent();
        }
        public AddTaskWindow(int day, int month, int year, DayWindow dayWindow)
        {
            InitializeComponent();
            picker.SelectedDate=new DateTime(year, month, day);
            this.dayWindow = dayWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(input.Text=="")
            {
                MessageBox.Show("Task can't be empty");
                return;
            }
            TaskManager.AddTask(picker.SelectedDate.Value.Day, picker.SelectedDate.Value.Month, picker.SelectedDate.Value.Year, input.Text);
            dayWindow.tasks.ItemsSource = null;
            dayWindow.day= new Day(dayWindow.day.day, dayWindow.day.month, dayWindow.day.year);
            dayWindow.tasks.ItemsSource = dayWindow.day.tasks;
            this.Close();

        }
    }
}

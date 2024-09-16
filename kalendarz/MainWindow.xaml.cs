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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace kalendarz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
           InitializeComponent();

            
            DateTime date = DateTime.Now;
            yearTextBox.Text = date.Year.ToString();
            monthCombo.SelectedIndex = date.Month - 1;
            setCalndarCard(date.Month, date.Year);
            

        }

        private void setCalndarCard(int month,int year)
        {
            grid.Children.Clear();
            List<List<Day>> days = new Month(month, year).days;
            for (int i = 0; i < days.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button button = new Button();
                    button.Content = days[i][j].day;
                    button.Width = 70;
                    button.Height = 50;
                    if (j == 6)
                    {
                        button.Background = new SolidColorBrush(Colors.IndianRed);
                    }
                    else if (j == 5)
                    {
                        button.Background = new SolidColorBrush(Colors.LightBlue);
                    }
                    else
                    {
                        button.Background = new SolidColorBrush(Colors.White);
                    }
                    if (days[i][j].disabled)
                    {
                        button.IsEnabled = false;
                        button.Background = new SolidColorBrush(Colors.LightGray);
                    }
                    if (days[i][j].tasks.Count > 0)
                    {
                        button.FontStyle = FontStyles.Italic;
                        button.Foreground = new SolidColorBrush(Colors.Lime);
                    }
                    button.Click += (sender, e) =>
                    {
                        int day= (int)button.Content;
                        onDateClick(day, month, year);
                    };
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    grid.Children.Add(button);

                }
            }
        }

        private void xd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "\r")
            {
                yearTextBox_LostFocus(sender, e);
                return;
               
            }
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void monthCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("monthCombo_SelectionChanged");
            int month = monthCombo.SelectedIndex + 1;
            int year = int.Parse(yearTextBox.Text);
            setCalndarCard(month, year);
        }

        private void yearTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int month = monthCombo.SelectedIndex + 1;
            int year = int.Parse(yearTextBox.Text);
            setCalndarCard(month, year);
        }
        private void onDateClick(int day, int month, int year)
        {
            DayWindow dayWindow = new DayWindow(new Day(day, month, year));
            dayWindow.Show();
            this.Close();
        }

        private void SelectPrevMonth(object sender, RoutedEventArgs e)
        {
            string year = yearTextBox.Text;
            int month = monthCombo.SelectedIndex + 1;
            if (month == 1)
            {
                month = 12;
                year = (int.Parse(year) - 1).ToString();
            }
            else
            {
                month--;
            }
            yearTextBox.Text = year;
            monthCombo.SelectedIndex = month - 1;
            setCalndarCard(month, int.Parse(year));

        }
        private void SelectNextMonth(object sender, RoutedEventArgs e)
        {
            string year = yearTextBox.Text;
            int month = monthCombo.SelectedIndex + 1;
            if (month == 12)
            {
                month = 1;
                year = (int.Parse(year) + 1).ToString();
            }
            else
            {
                month++;
            }
            yearTextBox.Text = year;
            monthCombo.SelectedIndex = month - 1;
            setCalndarCard(month, int.Parse(year));
        }

        
    }

}

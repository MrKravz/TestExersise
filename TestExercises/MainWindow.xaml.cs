using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using TestExercises.Models;

namespace TestExercises
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();

        }
        private void FillDataGrid()
        {
            users = MyJsonSerializer.GetAllUsers();
            List<UserGridInfo> userGridInfos = new List<UserGridInfo>();
            PersonGridInfoConfig config = new PersonGridInfoConfig();
            foreach (var item in users)
            {
                userGridInfos.Add(config.Generate(item.Name));
            }
            foreach (var item in userGridInfos)
            {
                MyData.Items.Add(item);
            }
        }

        private void MyData_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid dgr = sender as DataGrid;
                    if (dgr.SelectedItem != null && dgr.SelectedItems.Count == 1)
                    {
                        UserGridInfo userGridInfo = dgr.SelectedItem as UserGridInfo;
                        foreach (var item in users.Where(x => x.Name == userGridInfo.Name))
                        {
                            MyJsonSerializer.Serialaize(new SelectedUser(item.Rank, userGridInfo.Name, item.Status, userGridInfo.Average, userGridInfo.Best, userGridInfo.Worst));
                            MessageBox.Show($"You clicked on {item.Name}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool In20PercentRangeUP(UserGridInfo userGridInfo)
        {
            double avg = userGridInfo.Average * 0.2;
            return userGridInfo.Best > userGridInfo.Average + avg;
        }
        public bool In20PercentRangeDown(UserGridInfo userGridInfo)
        {
            double avg = userGridInfo.Average * 0.2;
            return userGridInfo.Worst < userGridInfo.Average - avg;
        }
        private void windowGrid_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MyData.Items.Count + 1; i++)
            {
                DataGridRow row = (DataGridRow)MyData.ItemContainerGenerator.ContainerFromIndex(i);
                if (row != null)
                {
                    UserGridInfo userGridInfo = (UserGridInfo)MyData.Items[i];
                    if (In20PercentRangeUP(userGridInfo))
                    {
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 104, 0));
                        row.Background = brush;
                    }
                    else if (In20PercentRangeDown(userGridInfo))
                    {
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 104, 0));
                        row.Background = brush;
                    }
                }
            }
        }
    }
}

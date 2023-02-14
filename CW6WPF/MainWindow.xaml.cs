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
using System.Data.OleDb;
using System.Windows.Markup;

namespace CW6WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6DB1.accdb");
        }

        private void AssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            //Employee ID Grabber
            string employeeIDData = "";
            string assetIDData = "";
            string descriptionData = "";
            while (read.Read())
            {
                employeeIDData += read[0].ToString() + "\n";
                assetIDData += read[1].ToString() + "\n";
                descriptionData += read[2].ToString() + "\n";
            }
            EmployeeIDDisplay.Text = employeeIDData;
            AssetIDDisplay.Text = assetIDData;
            AssetDescriptionDisplay.Text = descriptionData;

            cn.Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            //Employee ID Grabber
            string employeeIDData = "";
            string employeeNameData = "";
            while (read.Read())
            {
                employeeIDData += read[0].ToString() + "\n";
                employeeNameData += read[2].ToString() + " " + read[1].ToString() + "\n";
            }
            EmployeeIDDisplay_2.Text = employeeIDData;
            NameDisplay.Text = employeeNameData;

            cn.Close();
        }
    }
}

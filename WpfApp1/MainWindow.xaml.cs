using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.Data;
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
using System.Data.SqlClient;
using WpfApp1;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Sign_UpDetails Where txtFirstName=@txtFirstName and PasswordBox=@PasswordBox";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@txtFirstName", txtFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@PasswordBox", PasswordBox.Password);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar()); //returns the first record in the first row and the first column of your database
                if (count == 1)
                {
                    if (sqlCommand.ToString().Contains("Doctor"))
                    {
                        Window4 w1 = new Window4();
                        w1.Show();
                        //NavigationService.Navigate(new Uri("/Window3.xaml?key1=" + txtFirstName.Text, UriKind.Relative
                        this.Close();
                    }
                    if (sqlCommand.ToString().Contains("Nurse"))
                    {
                        Window2 w1 = new Window2();
                        w1.Show();
                        this.Close();
                    }
                    if (sqlCommand.ToString().Contains("Patient"))
                    {
                        Window5 w1 = new Window5();
                        w1.Show();
                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Password or username are not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close(); // close the connection to the database
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            this.Close();
        }
    }
}



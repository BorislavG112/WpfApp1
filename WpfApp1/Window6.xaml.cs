using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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



namespace Project
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 w1 = new Window4();
            w1.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection dbsCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
            try
            {
                dbsCon.Open();
                string query = "Select ID, txtFirstName, [PasswordBox], [Phone], [email], [Role] FROM Sign_UpDetails WHERE txtFirstName=@txtFirstName and PasswordBox=@PasswordBox";
                SqlCommand cmd = new SqlCommand(query, dbsCon);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGrid_.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                MessageBox.Show("Successful loading");
                dbsCon.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTable(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
            try
            {
                sqlCon.Open();
                string query = "select * from Appointments";

                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dT = new DataTable("Appointments");
                adapter.Fill(dT);
                DataGrid1.ItemsSource = dT.DefaultView;
                adapter.Update(dT);

                sqlCon.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

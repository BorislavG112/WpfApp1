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
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 w1 = new Window2();
            w1.Show();
            this.Close();
        }
        /*private void Button_Click(object sender, RoutedEventArgs e)
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
        }*/

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            //we establish the connection to the db
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
            try
            {
                //open connection to the db
                sqlCon.Open();
                string query = "Insert into Appointments (txtFirstName, Doctor, appointment_date, appointment_time) values ('" + this.txtFirstName.Text + "','" + this.Doctor.Text + "', '" + this.appointment_date.Text + "','" + this.appointment_time.Text + "')";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully created an appointment!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

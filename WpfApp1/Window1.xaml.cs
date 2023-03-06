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
using System;
using WpfApp1;

namespace Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string[] role { get; set; }

        public Window1()
        {
            InitializeComponent();
            role = new string[] { "Doctor", "Patient", "Nurse" };
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickPatientPage(object sender, RoutedEventArgs e)
        {
            Window2 w1 = new Window2();
            w1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*    try
                {
                    // Binding  
                    this.cmbCountryList.DisplayMemberPath = "CountryName";
                    this.cmbCountryList.SelectedValuePath = "CountryCode";
                    this.cmbCountryList.ItemsSource = HomeBusinessLogic.LoadCountryList();
                    this.cmbCountryList.Text = "Choose Country";
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }*/
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            //we establish the connection to the db
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
            try
            {
                //open connection to the db
                sqlCon.Open();
                string query = "Insert into Sign_UpDetails (txtFirstName, PasswordBox, email, Phone, Role) values ('" + this.txtFirstName.Text + "','" + this.txtPassword.Password + "', '" + this.txtEmail.Text + "','" + this.txtPhoneNumber.Text + "','" + this.cmbx_1.SelectedItem + "')";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully created a account!");
                if (this.cmbx_1.SelectedIndex == cmbx_1.Items.Count - 3)
                {
                    Window4 w1 = new Window4();
                    w1.Show();
                    this.Close();
                }
                if (this.cmbx_1.SelectedIndex == cmbx_1.Items.Count - 2)
                {
                    Window2 w1 = new Window2();
                    w1.Show();
                    this.Close();
                }
                if (this.cmbx_1.SelectedIndex == cmbx_1.Items.Count - 1)
                {
                    Window5 w1 = new Window5();
                    w1.Show();
                    this.Close();
                }




                /*if () {
                    Window1 w1 = new Window1();
                    w1.Show();
                    this.Close(); }
                if ()
                {
                    Window1 w1 = new Window1();
                    w1.Show();
                    this.Close();
                }
                if ()
                {
                    Window1 w1 = new Window1();
                    w1.Show();
                    this.Close();
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow();
            w1.Show();
            this.Close();
        }
    }
}



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for Window91.xaml
    /// </summary>
    public partial class Window91 : Window
    {
        public Window91()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window4 w1 = new Window4();
            w1.Show();
            this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Window1 mw1 = new Window1();
            try {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC17\LOCALHOST; Initial Catalog=HospitalDataSQL; Integrated Security=True");
                sqlCon.Open();

                string query = " select * from Sign_UpDetails where txtFirstName = '"+mw1.txtFirstName.Text + "'";
                //Establish a sql command

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    IDblock.Text = reader["ID"].ToString();
                    txtFirstNameblock.Text = reader["txtFirstName"].ToString();
                    PasswordBoxblock.Text = reader["PasswordBox"].ToString();
                    Phoneblock.Text = reader["Phone"].ToString();
                    emailblock.Text = reader["email"].ToString();
                    Roleblock.Text = reader["Role"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

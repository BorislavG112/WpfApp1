using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window5 w1 = new Window5();
            w1.Show();
            this.Close();
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

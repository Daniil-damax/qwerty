using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Data;
using System.Windows;

namespace WpfApp11
{
    class DataBase
    {
        public static string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danek\source\repos\WpfApp11\WpfApp11\Database2.mdf;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(connection_string);
        public static void FillDataGrid(DataGrid grid)
        {
            Kolvo();
            string sql = "SELECT ID,ComplexValueAdded,BuildingCost,Name,Status,KolvoHouse,City FROM ResidentialComplex WHERE IsDeleted = '0'";
            connection.Open();
            SqlCommand comm = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            grid.ItemsSource = table.DefaultView;
            grid.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            grid.Columns[1].Visibility = System.Windows.Visibility.Hidden;
            grid.Columns[2].Visibility = System.Windows.Visibility.Hidden;
            connection.Close();
        }

        public static void Kolvo()
        {
            string sql = "SELECT * FROM ResidentialComplex";
            connection.Open();
            SqlCommand comm = new SqlCommand(sql, connection);
            SqlDataReader reader = comm.ExecuteReader();
            List<int> ids = new List<int>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0].ToString());
                ids.Add(id);
            }
            reader.Close();
           
            
            for (int i = 0; i < ids.Count; i++)
            {
                int coll=0;
                string sql2 = $"SELECT * FROM House WHERE ResidentialComplexID = '{ids[i]}'";
                SqlCommand comm2 = new SqlCommand(sql2, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(comm2);
                DataTable table = new DataTable();
                adapter.Fill(table);
                coll = table.Rows.Count;
                string sql3 = $"UPDATE ResidentialComplex SET KolvoHouse = '{coll}' WHERE ID = '{ids[i]}'";
                SqlCommand comm3 = new SqlCommand(sql3, connection);
                comm3.ExecuteNonQuery();
                
            }
            connection.Close();
        }
        public static void RedaktComplex(int ID,string Name,int ComplexValueAdded,int BuildingCost, string City,string Status)
        {
            connection.Open();
            string sql = $"UPDATE ResidentialComplex SET Name=N'{Name}', ComplexValueAdded='{ComplexValueAdded}', BuildingCost='{BuildingCost}', City=N'{City}', Status=N'{Status}'  WHERE ID = '{ID}'";
            SqlCommand comm = new SqlCommand(sql, connection);
            comm.ExecuteNonQuery();
            MessageBox.Show("OK");
        }
        public static void City(DataGrid grid,int id)
        {
            connection.Open();
            string sql = $"SELECT Street,Number FROM House WHERE ResidentialComplexID = '{id}'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            grid.ItemsSource = table.DefaultView;
            connection.Close();
        }
        public static bool ProvKV(int id)
        {
            connection.Open();
            string sql = $"SELECT id FROM House WHERE ResidentialComplexID = '{id}'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<int> l = new List<int>();
            while (reader.Read())
            {
                int idH = Convert.ToInt32(reader[0].ToString());
                l.Add(idH);
            }
            reader.Close();
            for(int i = 0; i < l.Count; i++)
            {

            }
            return true;
        }
    }
}

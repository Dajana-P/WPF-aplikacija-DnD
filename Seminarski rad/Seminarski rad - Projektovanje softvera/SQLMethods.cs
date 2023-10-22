using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Seminarski_rad___Projektovanje_softvera
{
    class SQLMethods
    {

        public static string ConnString = @"Data Source=DESKTOP-PJ4U3BV\SQLEXPRESS;Initial Catalog=Seminarski Rad;Integrated Security=True";


        
        public static void PopuniTabelu(DataGrid tabela, string imeTabele)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from " + imeTabele;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tabela.ItemsSource = dt.DefaultView;
                tabela.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        public static void PopuniCMB(ComboBox cmb, string imeTabele, string imeKolone)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT " + imeKolone + " FROM " + imeTabele + "";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmb.Items.Add(reader[imeKolone].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        public static int PronadjiIDNecega(string imeTabele,string imeKolone,string vrednostKolone,string poljeID)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT " + poljeID + " FROM " + imeTabele + " WHERE " + imeKolone + "='" + vrednostKolone + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                int ID = Convert.ToInt32(reader[poljeID]);

                return ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        public static string PronadjiNestoPrekoID(string imeTabele,string imeIDPolja,string imeKolone,int ID)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT " + imeKolone + " FROM " + imeTabele + " WHERE " + imeIDPolja + "='" + ID + "'";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return reader[imeKolone].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "Greska";
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        public static void PopuniTabeluKarakteraZaUsername(DataGrid tabela,string Username)
        {
            string connectionString = SQLMethods.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Karakter WHERE Username='"+Username+"'";
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tabela.ItemsSource = dt.DefaultView;
                tabela.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
    }
}

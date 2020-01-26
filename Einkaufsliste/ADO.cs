using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace Einkaufsliste
{
    public class ADO
    {
        public static string ConnString = "server=localhost;user=root;database=ArtikelDatabase";

        public static DataTable DatenHochladen()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    string querry = "select * from Artikel;";
                    MySqlCommand cmd = new MySqlCommand(querry, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    return dt;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        public static void InsertNeueArtikel(string ArtkNummer, string Bezeichnung, int menge, bool erledigt)
        {
            try
            {
                string Query = "insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt  ) value('" + ArtkNummer + "','" + Bezeichnung + "','" + menge + "', '" + erledigt + "' ); ";
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = cmd.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }

        public static DataTable EinkauflisteErstellen()
            {
            try
            {
                string querry = "select * from Artikel where Erledigt= false;";
                 using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                     MySqlCommand cmd = new MySqlCommand(querry, conn);
                     MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                     adapter.Fill(dt);
                     return dt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
          

        }

        public static DataTable ErledigteListeErstellen()
        {

            try
            {
                string querry = "select * from Artikel where Erledigt= true;";
                using (MySqlConnection conn = new MySqlConnection(ConnString)) { 
                    MySqlCommand cmd = new MySqlCommand(querry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void updateErledigteArtikelnTrue( int id)
        {
            string query = "update Artikel set Erledigt=true where id= " + id  + ";";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
           
               
        }
        public static void updateErledigteArtikelnFalse(int id)
        {
            string query = "update Artikel set Erledigt=false where id= " + id + ";";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }


        }
    }
}

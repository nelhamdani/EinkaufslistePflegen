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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
 

namespace Einkaufsliste
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            // Listmenge Combobox  fühllen
            List<int> listMenge = new List<int>();
            for (int i=1; i<101; i++)
            {
                listMenge.Add(i);
            }
            ComboMengue.ItemsSource = listMenge;
            ComboMengue.SelectedIndex = 0;


            //Daten hochladen in den Grid

            datGListeArtikeln.ItemsSource = ADO.DatenHochladen().DefaultView;
             
             
        }

       

        private void BtnErlidigteListe_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ADO.ErledigteListeErstellen();

            using (StreamWriter Meinstream = new StreamWriter("ErledigteListeFile.txt"))
            {

                foreach (DataRow dr in dt.Rows)
                {

                    Meinstream.WriteLine("ArtilNummer: " + dr[1] + "| Bezeichnung: " + dr[2] + "| Menge: " + dr[3]);
                }
            }
            System.Windows.MessageBox.Show("Erledigte Liste ist erstellt");
        }

        private void BtneinkaufListe_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ADO.EinkauflisteErstellen();

            using (StreamWriter Meinstream = new StreamWriter("EnkaufListeFile.txt"))
            {

                foreach (DataRow dr in dt.Rows)
                {
                     
                    Meinstream.WriteLine("ArtilNummer: " + dr[1] + "| Bezeichnung: " + dr[2] + "| Menge: " +  dr[3] );
                }
            }
            System.Windows.MessageBox.Show("Einkaufsliste ist erstellt");
        }

        private void BtnEnde_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Neuer Artikel hinzufügen
           ADO. InsertNeueArtikel(TbNummer.Text, TbBezeichnung.Text,(int)ComboMengue.SelectedItem, false);


            // Datagrid refresh
            datGListeArtikeln.ItemsSource = null;
            datGListeArtikeln.ItemsSource = ADO.DatenHochladen().DefaultView;
            
        }

       

        

        
       

        private void OnUnchecked_Accepted(object sender, RoutedEventArgs e)
        {
            int MycurrentIndex = datGListeArtikeln.SelectedIndex;
            ADO.updateErledigteArtikelnFalse(MycurrentIndex + 1);

           

        }

        private void OnChecked_Accepted(object sender, RoutedEventArgs e)
        {
            int MycurrentIndex = datGListeArtikeln.SelectedIndex;
            ADO.updateErledigteArtikelnTrue(MycurrentIndex + 1);

           

        }
    }
 
}

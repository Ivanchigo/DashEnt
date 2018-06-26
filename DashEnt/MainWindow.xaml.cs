using System;
using System.Collections.Generic;
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
using System.Data.SQLite.EF6;

namespace DashEnt
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DbMani obDatos = new DbMani();

        private void cloTab_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(-1);
        }

        private void addDisp_Click(object sender, RoutedEventArgs e)
        {
            AddBitacora addBitacora = new AddBitacora();
                            
            addBitacora.ShowDialog();
        }

        private void addLeg_Click(object sender, RoutedEventArgs e)
        {
            AddLegado addLegado = new AddLegado();

            addLegado.ShowDialog();
        }

        private void addUat_Click(object sender, RoutedEventArgs e)
        {
            AddUat addUat = new AddUat();

            addUat.ShowDialog();
                 
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            obDatos.consultar("select * from TabBitacora", "TabBitacora");
            this.dataApp.ItemsSource = obDatos.ds.Tables["TabBitacora"];
            
        }
    }
}

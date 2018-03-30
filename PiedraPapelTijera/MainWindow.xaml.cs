using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PiedraPapelTijera
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int humano = 0;
        private int maquina = 0;
        private Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Piedra_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Piedra");
            Jugar("piedra");
        }

        private void Button_Papel_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Papel");
            Jugar("papel");
        }

        private void Button_Tijera_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Tijera");
            Jugar("tijera");
        }


        /*
         0 -> Gana A
         1 -> Empate
         2 -> Gana B
        */

        private void Jugar(String h)
        {
            String[] escoger = {"piedra", "papel", "tijera"};
            int m = r.Next() % 3;
            int ganador = Ganado(h, escoger[m]);



            if (ganador == 1) humano++;
            else if (ganador == 2) maquina++;

            this.DockHumanoLabel.Content = h.ToUpper();
            this.DockMaquinaLabel.Content = escoger[m].ToUpper();
            this.DockHumanoImage.Source = (ImageSource)FindResource(h);
            this.DockMaquinaImage.Source = (ImageSource)FindResource(escoger[m]);

            this.DockHumano.Visibility = Visibility.Visible;
            this.DockMaquina.Visibility = Visibility.Visible;

            this.ContadorHumano.Content = "Humano: " + humano;
            this.ContadorMaquina.Content = "Maquina: " + maquina;

        }
        
        private int Ganado(String a, String b)
        {
            if (a.Equals("piedra") && b.Equals("piedra") || a.Equals("papel") && b.Equals("papel") ||
                a.Equals("tijera") && b.Equals("tijera")) return 0; // Gana Humano
            if (a.Equals("piedra") && !b.Equals("papel") || a.Equals("papel") && !b.Equals("tijera") ||
                a.Equals("tijera") && !b.Equals("piedra")) return 1; // Gana máquina
            return 2; // Empate

        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using Label = System.Windows.Controls.Label;

namespace ipmemory
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush[] colors = { Brushes.Yellow , Brushes.LightGreen };
        Button[] bits;
        Label[] tags;

        public MainWindow()
        {
            InitializeComponent();

            bits = new Button[]{ b0, b1, b2, b3, b4, b5, b6, b7 };
            tags = new Label[] { l0, l1, l2, l3, l4, l5, l6, l7 };
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

            for(int i = 0; i < bits.Length; i++)
            {
                bits[i].Content = "0";
                bits[i].Background = colors[Convert.ToInt32(bits[i].Content)];
            }

            calcular();
        }

        void calcular()
        {
            int n = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                n += Convert.ToInt32(bits[i].Content) * Convert.ToInt32(Math.Pow(2, i));
            }

            txtResult.Content = Convert.ToString(n);
        }

        void clicarBit(Button b)
        {

            b.Content = b.Content.Equals("0")?"1":"0";
            b.Background = colors[Convert.ToInt32(b.Content)];

            calcular();

        }

        private void Bi_click(object sender, RoutedEventArgs e)
        {
            clicarBit((Button)sender);
        }

        private void Labels_click(object sender, MouseButtonEventArgs e)
        {            
            for (int i=0;i<tags.Length;i++)
            {
                tags[i].Content = tags[i].Content.Equals(Convert.ToInt32(Math.Pow(2, i)).ToString())? "2^" + i : Convert.ToInt32(Math.Pow(2, i)).ToString();
            }
        }

    }
}

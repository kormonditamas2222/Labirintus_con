using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabirintusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 5; i <= 20; i++)
            {
                cbSorokSzama.Items.Add(i);
                cbOszlopokSzama.Items.Add(i);
            }
            for (int i = 1; i <= 16; i++)
            {
                cbIndex.Items.Add(i);
            }
            cbOszlopokSzama.SelectedItem = 12;
            cbSorokSzama.SelectedItem = 12;
            cbIndex.SelectedItem = 3;
        }

        private void btnLetrehoz_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < myLab.Children.Count; i++)
            {
                if (myLab.Children[i] is CheckBox)
                {
                    myLab.Children.Remove(myLab.Children[i] as CheckBox);
                    i--;
                }
            }
            int sorokSzama = (int)cbSorokSzama.SelectedItem;
            int oszlopokSzama = (int)cbOszlopokSzama.SelectedItem;
            for (int r = 0; r < sorokSzama; r++)
            {
                for (int c = 0; c < oszlopokSzama; c++)
                {
                    CheckBox checkBox = new();
                    Canvas.SetLeft(checkBox, 20 + c * 15);
                    Canvas.SetTop(checkBox, 90 + r * 15);

                    if (r == 0 || r == sorokSzama -1 || c == 0 || c == oszlopokSzama - 1)
                    {
                        checkBox.IsChecked = true;
                        checkBox.IsEnabled = false;
                    }
                    if ((r == 1 && c == 0) || (c == oszlopokSzama-1 && r == sorokSzama-2))
                    {
                        checkBox.IsChecked = false;
                        checkBox.IsEnabled = false;
                    }
                    myLab.Children.Add(checkBox);
                }
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> ki = new();
            int sorokSzama = (int)cbSorokSzama.SelectedItem;
            int oszlopokSzama = (int)cbOszlopokSzama.SelectedItem;
            string sor = "";
            int sz = 0;
            foreach (var item in myLab.Children)
            {
                if (item is CheckBox)
                {
                    CheckBox cb = item as CheckBox ?? new();
                    sor += cb.IsChecked == true ? "X" : " ";
                    sz++;
                }
                if (sz == oszlopokSzama)
                {
                    ki.Add(sor);
                    sz = 0;
                    sor = "";
                }
            }
            try
            {
                File.WriteAllLines($"lab{cbIndex.SelectedItem}.txt", ki);
                MessageBox.Show("Az állomány mentése sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az állomány mentése során! " + ex.Message);
            }
        }
    }
}
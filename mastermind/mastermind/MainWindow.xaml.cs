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


namespace Mastermind
{
    public partial class MainWindow : Window
    {
        private List<string> colors = new List<string> { "Red", "Yellow", "Orange", "White", "Green", "Blue" };
        private List<string> code;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Generate a random code
            Random rand = new Random();
            code = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                code.Add(colors[rand.Next(colors.Count)]);
            }
            this.Title = "Mastermind - Code: " + string.Join(", ", code);

            // Populate ComboBoxes with color options
            ComboBox[] comboBoxes = { ComboBox1, ComboBox2, ComboBox3, ComboBox4 };
            for (int i = 0; i < comboBoxes.Length; i++)
            {
                comboBoxes[i].ItemsSource = colors;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            System.Windows.Controls.Label label = null;

            if (comboBox == ComboBox1) label = Label1;
            else if (comboBox == ComboBox2) label = Label2;
            else if (comboBox == ComboBox3) label = Label3;
            else if (comboBox == ComboBox4) label = Label4;

            if (label != null && comboBox.SelectedItem != null)
            {
                string selectedColor = comboBox.SelectedItem.ToString();
                label.Content = selectedColor;
                label.Background = GetColorBrush(selectedColor);
                label.BorderBrush = Brushes.Transparent; // Reset border color
            }
        }
        private Brush GetColorBrush(string colorName)
        {
            if (colorName == "Red") return Brushes.Red;
            if (colorName == "Yellow") return Brushes.Yellow;
            if (colorName == "Orange") return Brushes.Orange;
            if (colorName == "White") return Brushes.White;
            if (colorName == "Green") return Brushes.Green;
            if (colorName == "Blue") return Brushes.Blue;
            return Brushes.Transparent;
        }



    }
}

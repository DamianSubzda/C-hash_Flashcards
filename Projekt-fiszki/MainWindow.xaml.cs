using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace Projekt_fiszki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseConnector db = new DataBaseConnector();
        Flashcard f = new Flashcard();
        public MainWindow()
        {
            Console.WriteLine("hello world");
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //db.Connection();
        }
        public void test()
        {
            MessageBox.Show("hello world");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Textbox1.Text = db.Connection();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
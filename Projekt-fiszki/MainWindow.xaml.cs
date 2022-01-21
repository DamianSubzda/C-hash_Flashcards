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
    public partial class MainWindow : Window
    {

        public static DataBaseConnector db = new DataBaseConnector();
        public Remeber remember = new Remeber();
        private Flashcard f = new Flashcard(randFlashcard());
        private int firstLanguage = 1;
        private int secondLanguage = 2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            f = null;
            AddFlashCard();
        }
        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != f.elements.ElementAt(secondLanguage))
                label1.Background = Brushes.Red;
            else
                label1.Background = Brushes.LightGreen;
            TextBox1.Text = "";
        }
        private void AddFlashCard()
        {
            f = new Flashcard(randFlashcard());
            label1.Content = f.elements.ElementAt(firstLanguage); //Numerowane od 0 ale 0 to ID
            TextBox1.Text = "";
            label1.Background = Brushes.WhiteSmoke;
        }
        private static int randFlashcard()
        {
            int n = db.NumberOfRows();
            Random rand = new Random();
            return rand.Next(1, (n + 1)); //losuje od [n, m)
        }
        private void cb1_DropDownClosed(object sender, EventArgs e)
        {
            switch (cb1.Text)
            {
                case "Polski - Angielski":
                    firstLanguage = 1;
                    secondLanguage = 2;
                    break;
                case "Polski - Francuski":
                    firstLanguage = 1;
                    secondLanguage = 3;
                    break;
                case "Polski - Włoski":
                    firstLanguage = 1;
                    secondLanguage = 4;
                    break;
                case "Angielski - Polski":
                    firstLanguage = 2;
                    secondLanguage = 1;
                    break;
                case "Francuski - Polski":
                    firstLanguage = 3;
                    secondLanguage = 1;
                    break;
                case "Włoski - Polski":
                    firstLanguage = 4;
                    secondLanguage = 1;
                    break;
            }
            AddFlashCard();
        }

        private void Remember_Button_Click(object sender, RoutedEventArgs e)
        {
            String temp = null;
            temp = remember.parseString(firstLanguage, secondLanguage, f.elements.ElementAt(firstLanguage), f.elements.ElementAt(secondLanguage));

            Boolean x = remember.checkList(temp);
            if (x)
            {
                ListBox_Remember.Items.Add(temp);
            }
            
            
        }

        private void Button_Zapamietane_UsunWszystkie_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in ListBox_Remember.Items.OfType<string>().ToList())
                ListBox_Remember.Items.Remove(s);
        }

        private void Button_Zapamietane_Usun_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in ListBox_Remember.SelectedItems.OfType<string>().ToList())
                ListBox_Remember.Items.Remove(s);
        }

        private void Button_Click_New_Flashcard(object sender, RoutedEventArgs e)
        {
            AddFlashCard1();
            //MessageBox.Show("hi");
        }
        private void AddFlashCard1()
        {
            f = new Flashcard(randFlashcard());
            label2.Content = f.elements.ElementAt(firstLanguage); //Numerowane od 0 ale 0 to ID

        }
    }
}

//TODO 
/*  Duze i male litery nie mają znaczenia!
 *  zrobic w zapamietaniu bez powtorzen
 * 
 * 
 * */
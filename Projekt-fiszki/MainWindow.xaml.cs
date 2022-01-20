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
        public Remeber remeber = new Remeber();
        private Flashcard f = new Flashcard(randFlashcard());
        private int firstLanguage = 1;
        private int secondLanguage = 2;
        public MainWindow()
        {
            InitializeComponent();
            AddFlashCard();
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
            remeber.AddWords(f.elements.ElementAt(firstLanguage), f.elements.ElementAt(secondLanguage));

            String temp = "";
            switch (firstLanguage)
            {
                case 1:
                    temp = "Polski: \t";
                    break;
                case 2:
                    temp = "Angielski: \t";
                    break;
                case 3:
                    temp = "Francuski: \t";
                    break;
                case 4:
                    temp = "Włoski: \t";
                    break;
            }

            temp += f.elements.ElementAt(firstLanguage);

            switch (secondLanguage)
            {
                case 1:
                    temp += "\t Polski: \t";
                    break;
                case 2:
                    temp += "\t Angielski: \t";
                    break;
                case 3:
                    temp += "\t Francuski: \t";
                    break;
                case 4:
                    temp += "\t Włoski: \t";
                    break;
            }

            temp += f.elements.ElementAt(secondLanguage);
            ListBox_Remember.Items.Add(temp);
        }

        //List<String> one = remeber.getFirstWord();
        //List<String> two = remeber.getSecondWord();


        private void Show_remebered_Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            //MessageBox.Show(one.Last());
            //MessageBox.Show(two.Last());
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}

//TODO 
/*  Duze i male litery nie mają znaczenia!
 *  zrobic w zapamietaniu bez powtorzen
 * 
 * 
 * */
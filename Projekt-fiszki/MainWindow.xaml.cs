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
        private Flashcard f = null;
        public int numberOfQuestions = 3;
        private int firstLanguage = 1;
        private int secondLanguage = 2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            f = null;
            AddFlashCardWrite();
        }
        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != f.elements.ElementAt(secondLanguage))
                label1.Background = Brushes.Red;
            else
                label1.Background = Brushes.LightGreen;
            TextBox1.Text = "";
        }
        private void AddFlashCardWrite()
        {

            f = new Flashcard(randFlashcard());
            label1.Content = f.elements.ElementAt(firstLanguage); //Numerowane od 0 ale 0 to ID
            TextBox1.Text = "";
            label1.Background = Brushes.WhiteSmoke;
        }

        private void AddFlashCardTeach()
        {

            f = new Flashcard(randFlashcard());
            NewFlashCard_button.Content = f.elements.ElementAt(firstLanguage); //Numerowane od 0 ale 0 to ID
            NewFlashCard_button.Background = Brushes.IndianRed;
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
            AddFlashCardWrite();
        }

        private void cb2_DropDownClosed(object sender, EventArgs e)
        {
            switch (cb2.Text)
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
            AddFlashCardTeach();
        }
        private void Remember_Button_Click(object sender, RoutedEventArgs e)
        {
            if(f != null)
            {
                String temp = null;
                temp = remember.parseString(firstLanguage, secondLanguage, f.elements.ElementAt(firstLanguage), f.elements.ElementAt(secondLanguage));

                Boolean x = remember.checkList(temp);
                if (x == true)
                {
                    ListBox_Remember.Items.Add(temp);
                }
            }
        }

        private void Show_remebered_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Zapamietane_UsunWszystkie_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in ListBox_Remember.Items.OfType<string>().ToList())
            {
                remember.DeleteWord(s);
                ListBox_Remember.Items.Remove(s);
            }

        }

        private void Button_Zapamietane_Usun_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in ListBox_Remember.SelectedItems.OfType<string>().ToList())
            {
                remember.DeleteWord(s);
                ListBox_Remember.Items.Remove(s);
            }

        }
        
        private void Button_Click_New_Flashcard(object sender, RoutedEventArgs e)
        {
            AddFlashCardTeach();
            NewFlashCard_button.Background = Brushes.IndianRed;
        }

        private void NewFlashCard_button_MouseEnter(object sender, MouseEventArgs e)
        {
            if(f!=null)
            {
                NewFlashCard_button.Content = f.elements.ElementAt(secondLanguage);
                NewFlashCard_button.Background = Brushes.IndianRed;
            }
                
            else
                NewFlashCard_button.Content = "...";
        }

        private void NewFlashCard_button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (f != null)
            {
                NewFlashCard_button.Content = f.elements.ElementAt(firstLanguage);
                NewFlashCard_button.Background = Brushes.BlueViolet;
            }
                
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 3;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 5;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 10;
        }

        private void Button_Click_Start_Test(object sender, RoutedEventArgs e)
        {
            rb1.Visibility = Visibility.Hidden;
            rb2.Visibility = Visibility.Hidden;
            rb3.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            start_test.Visibility = Visibility.Hidden;
            cb3.Visibility = Visibility.Hidden;
            //
            TextBox2.Visibility = Visibility.Visible;
            rec.Visibility = Visibility.Visible;
            border.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            nextTest.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;

            label4.Content = $"Progres: 1/{numberOfQuestions}";

            Test test = new Test(numberOfQuestions);
            Flashcard t = test.getFlashcard(0);
            label2.Content = t.elements.ElementAt(firstLanguage);

        }
    }
}

//TODO 
/*  Duze i male litery nie mają znaczenia!
 *  zrobic w zapamietaniu bez powtorzen
 * 
 * 
 * */
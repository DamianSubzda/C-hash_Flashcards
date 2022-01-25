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
using System.Windows.Threading;

namespace Projekt_fiszki
{
    public partial class MainWindow : Window
    {

        private static DataBaseConnector db = new DataBaseConnector();
        private Remeber remember = new Remeber();
        private Flashcard f_Teach = null;
        private Flashcard f = null;
        private Flashcard f_race = null;
        private int numberOfQuestions = 3;
        private int firstLanguage = 1;
        private int secondLanguage = 2;
        private int nr_label;
        private Test test;
        private int score_test;
        private Flashcard t;
        private int time = 10;
        private DispatcherTimer Timer;
        private int numberOfQuestions_race = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            f = null;
            AddFlashCardWrite();
            checkCorrect.Visibility = Visibility.Hidden;
            TextBox1.Text = "";
        }

        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            if (f == null) { }
            else
            {
                if (TextBox1.Text != f.elements.ElementAt(secondLanguage))
                {
                    label1.Background = Brushes.Red;
                    checkCorrect.Visibility = Visibility.Visible;
                }
                else
                    label1.Background = Brushes.LightGreen;
            }
            
        }

        private void checkCorrect_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = f.elements.ElementAt(secondLanguage);
            label1.Background = Brushes.Bisque;
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

            f_Teach = new Flashcard(randFlashcard());
            NewFlashCard_button.Content = f_Teach.elements.ElementAt(firstLanguage); //Numerowane od 0 ale 0 to ID
            NewFlashCard_button.Background = Brushes.IndianRed;
        }

        private void AddFlashCardRace()
        {
            f_race = new Flashcard(randFlashcard());
            label8.Content = f_race.elements.ElementAt(firstLanguage);
            TextBox3.Text = "";

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

        private void cb3_DropDownClosed(object sender, EventArgs e)
        {
            switch (cb3.Text)
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
        }

        private void cb4_DropDownClosed(object sender, EventArgs e)
        {
            switch (cb4.Text)
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
        }

        private void Remember_Button_Click(object sender, RoutedEventArgs e)
        {
            if(f_Teach != null)
            {
                String temp = null;
                temp = remember.parseString(firstLanguage, secondLanguage, f_Teach.elements.ElementAt(firstLanguage), f_Teach.elements.ElementAt(secondLanguage));

                Boolean x = remember.checkList(temp);
                if (x == true)
                {
                    ListBox_Remember.Items.Add(temp);
                }
            }
            else if(f != null)
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
            if (f_Teach != null)
            {
                NewFlashCard_button.Content = f_Teach.elements.ElementAt(secondLanguage);
                NewFlashCard_button.Background = Brushes.IndianRed;
            }
            else
                NewFlashCard_button.Content = "...";
        }

        private void NewFlashCard_button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (f_Teach != null)
            {
                NewFlashCard_button.Content = f_Teach.elements.ElementAt(firstLanguage);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 3;
            time = 10;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 5;
            time = 30;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            numberOfQuestions = 10;
            time = 60;
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

            score_test = 0;
            nr_label = 1;
            label4.Content = $"Progres: {nr_label}/{numberOfQuestions}";
            test = new Test(numberOfQuestions);
            t = test.getFlashcard(0);
            label2.Content = t.elements.ElementAt(firstLanguage);
            nr_label = 2;

        }

        private void nextTest_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text == t.elements.ElementAt(secondLanguage))
                score_test++;
            TextBox2.Text = "";
            t = test.getFlashcard(nr_label-1);
            label4.Content = $"Progres: {nr_label}/{numberOfQuestions}";
            label2.Content = t.elements.ElementAt(firstLanguage);
            nr_label++;
            
            if (nr_label == numberOfQuestions + 1)
            {
                nextTest.Visibility = Visibility.Hidden;
                endTest.Visibility = Visibility.Visible;
            }

        }

        private void endTest_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox2.Text == t.elements.ElementAt(secondLanguage))
                score_test++;
            t = null;
            TextBox2.Text = "";
            endTest.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Hidden;
            rec.Visibility = Visibility.Hidden;
            border.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            nextTest.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Visible;
            newTest_button.Visibility = Visibility.Visible;
            label6.Content = $"Twój wynik to {score_test}/{numberOfQuestions}.";
        }

        private void newTest_button_Click(object sender, RoutedEventArgs e)
        {
            test = null;
            label6.Visibility = Visibility.Hidden;
            newTest_button.Visibility = Visibility.Hidden;
            rb1.Visibility = Visibility.Visible;
            rb2.Visibility = Visibility.Visible;
            rb3.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            start_test.Visibility = Visibility.Visible;
            cb3.Visibility = Visibility.Visible;

        }

        private void Timer_Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            Counter.Text = $"{time % 6000 / 600}{time % 600 / 60}:{time % 60 / 10}{time % 10}";
            Counter_Start_Button.Visibility = Visibility.Hidden;
            Counter.Visibility = Visibility.Visible;
            label7.Visibility = Visibility.Hidden;
            rb1_w.Visibility = Visibility.Hidden;
            rb2_w.Visibility = Visibility.Hidden;
            rb3_w.Visibility = Visibility.Hidden;
            //
            label8.Visibility = Visibility.Visible;
            TextBox3.Visibility = Visibility.Visible;
            next_w.Visibility = Visibility.Visible;
            label9.Visibility = Visibility.Visible;
            border1.Visibility = Visibility.Visible;
            rectangle1.Visibility = Visibility.Visible;
            //
            label8.Content = "...";


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(time > 0)
            {
                time--;
                Counter.Text = $"{time%6000 / 600}{time%600 / 60}:{time%60 / 10}{time % 10}";
            }
            else
            {
                Timer.Stop();
                endRace();
            }
        }

        private void endRace()
        {
            time = 10;
            rb1_w.IsChecked = true;
            Counter.Visibility = Visibility.Hidden;
            label8.Visibility = Visibility.Hidden;
            TextBox3.Visibility = Visibility.Hidden;
            next_w.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            border1.Visibility = Visibility.Hidden;
            rectangle1.Visibility = Visibility.Hidden;
            //
            label10.Visibility = Visibility.Visible;
            newRace_button.Visibility = Visibility.Visible;
            label10.Content = $"Twoj wynik to: {score_test}/{numberOfQuestions_race}";
            f_race = null;

        }


        private void Button_Click_Next_w(object sender, RoutedEventArgs e)
        {
            
            if(f_race != null)
            {
                if(f_race.elements.ElementAt(secondLanguage) == TextBox3.Text)
                {
                    score_test++;
                }
                numberOfQuestions_race++;
            }
            AddFlashCardRace();

        }

        private void newRace_button_Click(object sender, RoutedEventArgs e)
        {
            label10.Visibility = Visibility.Hidden;
            newRace_button.Visibility = Visibility.Hidden;
            //
            Counter_Start_Button.Visibility = Visibility.Visible;
            label7.Visibility = Visibility.Visible;
            rb1_w.Visibility = Visibility.Visible;
            rb2_w.Visibility = Visibility.Visible;
            rb3_w.Visibility = Visibility.Visible;
            numberOfQuestions_race = 0;
            score_test = 0;

        }
    }
}

//TODO 
/*  Duze i male litery nie mają znaczenia! ->   string.Equals(name, "ashley", StringComparison.CurrentCultureIgnoreCase);
 *                                          ->  if (String.Compare(name, "ashley", true) == 0)
 *  Upewnić się, że wszystkie zmienne są po angielsku etc!
 *  
 *  W radioButtonach dodać czas niestandardowy
 * 
 * */
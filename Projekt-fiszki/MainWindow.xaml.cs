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
        private Flashcard f_write = null;
        private Flashcard f_race = null;
        public int numberOfQuestions = 3;
        private int nr_label;
        private Test test;
        private Flashcard t;
        private int score_test;
        private int time = 10;
        private DispatcherTimer Timer;
        private int numberOfQuestions_race = 0;

        private ComboBox combob1 = new ComboBox(1,2);
        private ComboBox combob2 = new ComboBox(1,2);
        private ComboBox combob3 = new ComboBox(1,2);
        private ComboBox combob4 = new ComboBox(1,2);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            f_write = null;
            AddFlashCardWrite();
            checkCorrect.Visibility = Visibility.Hidden;
            TextBox1.Text = "";
        }

        private void Button_Click_Check(object sender, RoutedEventArgs e)
        {
            if (f_write == null) { }
            else
            {
                if (!(string.Equals(TextBox1.Text, f_write.elements.ElementAt(combob2.secondLanguage), StringComparison.CurrentCultureIgnoreCase)))
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
            label1.Content = f_write.elements.ElementAt(combob2.secondLanguage);
            label1.Background = Brushes.Bisque;
        }

        private void AddFlashCardWrite()
        {

            f_write = new Flashcard(randFlashcard());
            label1.Content = f_write.elements.ElementAt(combob2.firstLanguage); //Numerowane od 0 ale 0 to ID
            TextBox1.Text = "";
            label1.Background = Brushes.WhiteSmoke;
        }

        private void AddFlashCardTeach()
        {

            f_Teach = new Flashcard(randFlashcard());
            NewFlashCard_button.Content = f_Teach.elements.ElementAt(combob1.firstLanguage); //Numerowane od 0 ale 0 to ID
            NewFlashCard_button.Background = Brushes.IndianRed;
        }

        private void AddFlashCardRace()
        {
            f_race = new Flashcard(randFlashcard());
            label8.Content = f_race.elements.ElementAt(combob4.firstLanguage);
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
            combob1.setLanguage(cb1.Text);
            AddFlashCardTeach();
        }

        private void cb2_DropDownClosed(object sender, EventArgs e)
        {
            combob2.setLanguage(cb2.Text);
            AddFlashCardWrite();
        }

        private void cb3_DropDownClosed(object sender, EventArgs e)
        {
            combob3.setLanguage(cb3.Text);
        }

        private void cb4_DropDownClosed(object sender, EventArgs e)
        {
            combob4.setLanguage(cb4.Text);
        }

        private void Remember_Button_Click(object sender, RoutedEventArgs e)
        {
            if (f_Teach != null)
            {
                String temp = null;
                temp = remember.parseString(combob1.firstLanguage, combob1.secondLanguage, f_Teach.elements.ElementAt(combob1.firstLanguage), f_Teach.elements.ElementAt(combob1.secondLanguage));

                Boolean x = remember.checkList(temp);
                if (x == true)
                {
                    ListBox_Remember.Items.Add(temp);
                }
            }
            else if (f_write != null)
            {
                String temp = null;
                temp = remember.parseString(combob2.firstLanguage, combob2.secondLanguage, f_write.elements.ElementAt(combob2.firstLanguage), f_write.elements.ElementAt(combob2.secondLanguage));

                Boolean x = remember.checkList(temp);
                if (x == true)
                {
                    ListBox_Remember.Items.Add(temp);
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Remember_DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in ListBox_Remember.Items.OfType<string>().ToList())
            {
                remember.DeleteWord(s);
                ListBox_Remember.Items.Remove(s);
            }

        }

        private void Button_Remember_Delete_Click(object sender, RoutedEventArgs e)
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
            //NewFlashCard_button.Background = Brushes.IndianRed;
        }

        private void NewFlashCard_button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (f_Teach != null)
            {
                NewFlashCard_button.Content = f_Teach.elements.ElementAt(combob1.secondLanguage);
                NewFlashCard_button.Background = Brushes.IndianRed;
            }
            else
                NewFlashCard_button.Content = "...";
        }

        private void NewFlashCard_button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (f_Teach != null)
            {
                NewFlashCard_button.Content = f_Teach.elements.ElementAt(combob1.firstLanguage);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
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

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_Start_Test(object sender, RoutedEventArgs e)
        {

            Boolean temp = false;
            if (rb4.IsChecked == true)
            {
                try
                {
                    numberOfQuestions = Convert.ToInt32(TextBox5.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Zły format danych!");
                    temp = true;
                }
            }
            if (temp == false)
            {
                Grid2.Visibility = Visibility.Hidden;
                Grid1.Visibility = Visibility.Visible;
                nextTest.Visibility = Visibility.Visible;

                score_test = 0;
                nr_label = 1;
                label4.Content = $"Progres: {nr_label}/{numberOfQuestions}";
                test = new Test(numberOfQuestions);
                t = test.getFlashcard(0);
                label2.Content = t.elements.ElementAt(combob3.firstLanguage);
                nr_label = 2;
            }
            rb1.IsChecked = true;
            TextBox5.Text = "";
        }

        private void nextTest_Click(object sender, RoutedEventArgs e)
        {
            if (string.Equals(TextBox2.Text, t.elements.ElementAt(combob3.secondLanguage), StringComparison.CurrentCultureIgnoreCase))
                score_test++;
            TextBox2.Text = "";
            t = test.getFlashcard(nr_label - 1);
            label4.Content = $"Progres: {nr_label}/{numberOfQuestions}";
            label2.Content = t.elements.ElementAt(combob3.firstLanguage);
            nr_label++;

            if (nr_label == numberOfQuestions + 1)
            {
                nextTest.Visibility = Visibility.Hidden;
                endTest.Visibility = Visibility.Visible;
            }

        }

        private void endTest_Click(object sender, RoutedEventArgs e)
        {
            if (string.Equals(TextBox2.Text, t.elements.ElementAt(combob3.secondLanguage), StringComparison.CurrentCultureIgnoreCase))
                score_test++;
            t = null;
            TextBox2.Text = "";
            endTest.Visibility = Visibility.Hidden;
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Visible;
            label6.Content = $"Twój wynik to {score_test}/{numberOfQuestions}.";
            double temp2 = Convert.ToDouble(score_test)/ Convert.ToDouble(numberOfQuestions )* 100;
            int temp = Convert.ToInt32(Math.Round(temp2, 2, MidpointRounding.ToEven));
            label15.Content = $"Procentowo: {temp}%";
        }

        private void newTest_button_Click(object sender, RoutedEventArgs e)
        {
            test = null;
            Grid3.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Visible;

        }

        private void Timer_Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Boolean temp = false;
            if (rb4_w.IsChecked == true)
            {
                try
                {
                    time = Convert.ToInt32(TextBox4.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Zły format danych!");
                    TextBox4.Text = "";
                    rb1_w.IsChecked = true;
                    temp = true;
                }
            }
            if (temp == false)
            {
                Timer = new DispatcherTimer();
                Timer.Interval = new TimeSpan(0, 0, 1);
                Timer.Tick += Timer_Tick;
                Timer.Start();
                Counter.Text = $"{time % 6000 / 600}{time % 600 / 60}:{time % 60 / 10}{time % 10}";
                Grid4.Visibility = Visibility.Hidden;
                Grid5.Visibility = Visibility.Visible;
                label8.Content = "...";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                Counter.Text = $"{time % 6000 / 600}{time % 600 / 60}:{time % 60 / 10}{time % 10}";
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
            Grid5.Visibility = Visibility.Hidden;
            Grid6.Visibility = Visibility.Visible;
            label10.Content = $"Twoj wynik to: {score_test}/{numberOfQuestions_race}";
            f_race = null;

        }

        private void Button_Click_Next_w(object sender, RoutedEventArgs e)
        {

            if (f_race != null)
            {
                if (string.Equals(TextBox3.Text, f_race.elements.ElementAt(combob4.secondLanguage), StringComparison.CurrentCultureIgnoreCase))
                {
                    score_test++;
                }
                numberOfQuestions_race++;
            }
            AddFlashCardRace();

        }

        private void newRace_button_Click(object sender, RoutedEventArgs e)
        {
            Grid6.Visibility = Visibility.Hidden;
            Grid4.Visibility = Visibility.Visible;
            numberOfQuestions_race = 0;
            score_test = 0;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_fiszki
{
    public class Test
    {
        private List<Flashcard> testFlashCards = new List<Flashcard>();
        public static DataBaseConnector db = new DataBaseConnector();
        public int numberOfQuestions;

        public Test(int numberOfQuestions)
        {
            this.numberOfQuestions = numberOfQuestions;
            setFlashCards();
        }

        public void setFlashCards()
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Flashcard f = new Flashcard(randFlashcard());
                testFlashCards.Add(f);
            }
        }

        public Flashcard getFlashcard(int ID)
        {
            return testFlashCards.ElementAt(ID);
        }
        public int randFlashcard()
        {
            int n = db.NumberOfRows();
            Random rand = new Random();
            return rand.Next(1, (n + 1)); //losuje od [n, m)
        }
    }
}

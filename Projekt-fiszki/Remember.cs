using System;
using System.Collections.Generic;

public class Remeber
{
    public List<String> rememberElement = new List<string>();
    public Remeber()
    {
    }
    public void AddWord(String temp)
    {
        rememberElement.Add(temp);
    }
    /*
    public List<String> getFirstWord()
    {
        return firstWord;
    }
    public List<String> getSecondWord()
    {
        return secondWord;
    }
    */
    public String parseString(int firstLanguage, int secondLanguage, String firstWord, String secondWord)
    {
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

        temp += firstWord;

        switch (secondLanguage)
        {
            case 1:
                temp += "\t\t Polski: \t";
                break;
            case 2:
                temp += "\t\t Angielski: \t";
                break;
            case 3:
                temp += "\t\t Francuski: \t";
                break;
            case 4:
                temp += "\t\t Włoski: \t";
                break;
        }

        temp += secondWord;
        
        return temp;
    }
    public Boolean checkList(String temp)
    {
        //if(jest w liście to){
        //    return false;
        //}
        //else
        //{
        //    AddWord(temp);
        //    return true;
        //}
        return false; //albo true
    }
}
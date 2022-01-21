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

    public void DeleteWord(String temp)
    {
        rememberElement.Remove(temp);
    }
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

        temp += secondWord;

        return temp;
    }
    public Boolean checkList(String temp)
    {
        foreach (String a in rememberElement)
        {
            if (temp == a)
                return false;
        }
        AddWord(temp);
        return true;
        for (int i = 0; i < rememberElement.Count; i++)
        {
            if (temp == rememberElement[i])
                return false;
        }

    }
}
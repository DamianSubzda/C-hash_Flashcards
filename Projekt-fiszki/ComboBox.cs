using System;

public class ComboBox
{
    public int firstLanguage = 0;
    public int secondLanguage = 0;
    public ComboBox(int firstLanguage, int secondLanguage)
    {
        this.firstLanguage = firstLanguage;
        this.secondLanguage = secondLanguage;
    }
    
    public void setLanguage(String str)
    { 
        switch (str)
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
}

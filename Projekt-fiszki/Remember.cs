using System;
using System.Collections.Generic;

public class Remeber
{
	public List<String> firstWord = new List<string>();
	public List<String> secondWord = new List<string>();
	public Remeber()
	{
	}
	public void AddWords(String one, String two)
    {
		firstWord.Add(one);
		secondWord.Add(two);
    }
	public List<String> getFirstWord()
    {
		return firstWord;
    }
	public List<String> getSecondWord()
	{
		return secondWord;
	}

}

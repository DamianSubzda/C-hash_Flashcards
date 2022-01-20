using System;
using System.Collections.Generic;

public class Flashcard
{
	public int ID;
	public List<String> elements;
	private DataBaseConnector db = new DataBaseConnector();
	public Flashcard(int ID)
	{
		this.ID = ID;
		elements = getElements(ID);
	}

	private List<String> getElements(int ID){
		elements = db.Connection(ID);
		return elements;
	}

}

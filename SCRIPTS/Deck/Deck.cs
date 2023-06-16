using Godot;
using System;
using System.Collections.Generic;
using System.IO;

//TODO create a deck resource based on this 

public class Deck : IDeck
{
	private List<ICard> CardArray;



	public void AddCard(ICard card)
	{
		CardArray.Add(card);
	}
	

	ICard IDeck.GetCard(string name)
	{
		throw new NotImplementedException();
	}

	public  ICard GetCard(string name)
	{
		bool isNotFound = true;
		for (int i = 0; i < CardArray.Count; i++)
		{
			if (CardArray[i].GetCardName() != null)
			{
				return CardArray[i];
			}
		}

		return null;
	}

	public  void Shuffle()
	{
		Random rnd = new Random();
		for (int i = 0; i < CardArray.Count; i++)
		{
			int swapIndex = rnd.Next(0, CardArray.Count);
			if (swapIndex != i)
			{
				ICard temp = CardArray[swapIndex];
				CardArray[swapIndex] = CardArray[i];
				CardArray[i] = temp;
			}
		}
	}

	public void AddCardToList(CardRes card)
	{
		throw new NotImplementedException();
	}

	public void WriteCardListToFile(ref StreamWriter sw_out)
	{
		throw new NotImplementedException();
	}
}

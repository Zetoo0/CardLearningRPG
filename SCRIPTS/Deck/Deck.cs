using Godot;
using System;
using System.Collections.Generic;

//TODO create a deck resource based on this 

public class Deck : DeckBase
{
	private List<Card> CardArray;

	public void SaveDeck()
	{
		
	}

	public override void AddCard(Card card)
	{
		CardArray.Add(card);
	}

	public override Card GetCard(string name)
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

	public override void Shuffle()
	{
		Random rnd = new Random();
		for (int i = 0; i < CardArray.Count; i++)
		{
			int swapIndex = rnd.Next(0, CardArray.Count);
			if (swapIndex != i)
			{
				Card temp = CardArray[swapIndex];
				CardArray[swapIndex] = CardArray[i];
				CardArray[i] = temp;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return base.ToString();
	}
}

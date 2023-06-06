 using Godot;
using System;

public partial class DeckHandle : Node
{
	public static DeckRess currDeckCreate;
	public static DeckHandle _deckHandle;

	public static void CreateDeckResource()
	{
		//Create a resource for the deck
		currDeckCreate = new DeckRess();
	}

	

	public static void CreateDeckResource(DeckRess res)
	{
		currDeckCreate = res;
		//GD.Print(currDeckCreate._cardList);
	}
	
	public static DeckRess GetCurrentCreateDeck()
	{
		return currDeckCreate;
	}
	
}



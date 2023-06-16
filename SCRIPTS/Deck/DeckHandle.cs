 using Godot;
using System;

public partial class DeckHandle : Node, IDeckHandle
{
	public static DeckRess currDeckCreate;
	public static CardRes currCardResInPlay;
	public static DeckHandle _deckHandle;

	public static void CreateDeckResource()
	{
		//Create a resource for the deck
		currDeckCreate = new DeckRess();
	}

	public static string GetCurrentPlayCardSolution()
	{
		return currCardResInPlay.GetSolution();
	}

	public static string[] GetCurrentPlayCardAddInfo()
	{
		return currCardResInPlay.GetAdditionalInformations();
	}

	public static void SetCurrentPlayCardSol(string sol)
	{
		currCardResInPlay.SetSolution(sol);
	}

	public static void CreateDeckResource(DeckRess res)
	{
		currDeckCreate = res;
	}
	
	public static DeckRess GetCurrentCreateDeck()
	{
		return currDeckCreate;
	}

	public static void SetDeckRes(DeckRess deckRes)
	{
		currDeckCreate = deckRes;
		GD.Print("Deck res added: " + deckRes._cardList[0].GetTask());
	}
	
}



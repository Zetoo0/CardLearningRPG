using Godot;
using System;
using System.Linq;

public partial class DeckLoaderIntoPlay : Node
{

	private static int currCardInstanceLoadNum;

	public override void _Ready()
	{
		LoadCardsIntoDeck();
		TestDeckNShit();
	}

	/*public override void _Process(double delta)
	{
		GD.Print(CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay());
	}*/

	private void TestDeckNShit()
	{
		CurrentPlayDeckCardInformation.SetCurrentCardIndexInPlayToZero();
		CurrentPlayDeckCardInformation.SetCurrentCardInPlay(DeckHandle.GetCurrentCreateDeck()._cardList[CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay()]);
		foreach (Node node in this.GetChildren())
		{
			GD.Print(node.Name);
		}
	}
	
	public static int GetCurrCardInstanceLoadIndex()
	{
		return currCardInstanceLoadNum;
	}

	private void LoadCardsIntoDeck()
	{
		for (int i = 0; i < DeckHandle.GetCurrentCreateDeck()._cardList.Count; i++)
		{
			currCardInstanceLoadNum = i;
			InstantinateNewCardIntoDeck();
		}
	}

	private void InstantinateNewCardIntoDeck()
	{
		PackedScene CardNode = GD.Load<PackedScene>("res://SCENES/Card.tscn");
		Node CardInstance = CardNode.Instantiate();
		GD.Print("apád");
		AddChild(CardInstance);
		
	}

	public void ChangeCard()
	{
		if (CurrentPlayDeckCardInformation.GetIsCanChangeCard())
		{
			Node2D currCard = (Node2D)this.GetChild(CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay());
			GD.Print("Current card:"+currCard.Name);
			currCard.Visible = false;
			//set the current card and da index  after the invisibility
			CurrentPlayDeckCardInformation.IncrementCurrentCardIndexInPlay();
			CurrentPlayDeckCardInformation.SetCurrentCardInPlay(DeckHandle.GetCurrentCreateDeck()._cardList[CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay()]);
			//currCard.Free();
			//CurrentPlayDeckCardInformation.IncrementCurrentCardIndexInPlay();
			Node2D nextCard = (Node2D)this.GetChild(CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay());
			GD.Print("Next card: "+nextCard.Name);
			nextCard.Visible = true;
		}
		else {
			GD.Print("Cannot change card");	
			
		}
		//currCard.Free();
	}
	
}

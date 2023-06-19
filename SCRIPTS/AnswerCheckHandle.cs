using Godot;
using System;

public partial class AnswerCheckHandle : Node
{
	private AnswerChecker _checker;
	
	public override void _Ready()
	{
		_checker = new AnswerChecker();
	}

	public void StartCheck()
	{
		//DeckHandle.currCardResInPlay = DeckHandle.GetCurrentCreateDeck()._cardList[0];
		//CurrentPlayDeckCardInformation.SetCurrentCardInPlay(DeckHandle.GetCurrentCreateDeck()._cardList[0]);
	//	GD.Print(DeckHandle.GetCurrentPlayCardSolution());
		//CurrentPlayDeckCardInformation.SetCurrentCardInPlaySolution(DeckHandle.GetCurrentCreateDeck()._cardList[0].GetSolution());
		//DeckHandle.SetCurrentPlayCardSol(DeckHandle.GetCurrentCreateDeck()._cardList[0].GetSolution());
		//GD.Print(GetNode<LineEdit>("CanvasLayer/MainRect/AnswerText").Text);
		_checker.SetUserAnswer(GetNode<LineEdit>("/root/Node2D/CanvasLayer/MainRect/AnswerText").Text);
		_checker.SetSolutionAndStartCheck(CurrentPlayDeckCardInformation.GetCurrentCardInPlay().GetSolution());//TODO create a new class for store the current card information
	}



}

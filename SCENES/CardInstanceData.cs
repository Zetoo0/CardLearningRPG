using Godot;
using System;

public partial class CardInstanceData : Node2D, ICardInstanceData
{
	private Label task_Sol_Lb;
	private Label add_Inf_Lb;
	private string task;
	private string sol;
	private string[] add_inf;
	private Action e;
	public override void _Ready()
	{
		task_Sol_Lb = GetNode<Label>("CardRect/CardTaskSolLb");
		add_Inf_Lb = GetNode<Label>("CardRect/CardAddInfLb");
		add_Inf_Lb.Visible = false;
		SetCurrentCardsText();
		
	}

	private void SetCurrentCardsText()
	{
		if (DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex() != 0)
		{
			GD.Print(DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex().ToString());
			GD.Print(DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetTask());
			GD.Print(DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetSolution());
			task = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetTask();
			sol = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetSolution();
			add_inf = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetMeanings();
			task_Sol_Lb.Text = task;
			this.Visible = false;
		}
		else
		{
			
			GD.Print("NULLADIK______-----");
			GD.Print(DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex().ToString());
			GD.Print(DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetTask());
			GD.Print(DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetSolution());
			task = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetTask();
			sol = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetSolution();
			add_inf = DeckHandle.GetCurrentCreateDeck()._cardList[DeckLoaderIntoPlay.GetCurrCardInstanceLoadIndex()].GetMeanings();
			task_Sol_Lb.Text = task;
			//DeckHandle.SetCurrCardResIndexInPlayTo(0);
		}
		

		//add_Inf_Lb.Text = add_inf[0];


	}
}

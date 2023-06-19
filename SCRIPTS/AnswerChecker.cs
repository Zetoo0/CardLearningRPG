using Godot;
using System;
using learningERpig.SCRIPTS.UI;

public partial class AnswerChecker :Node, IAnswerChecker
{
	private string solution;
	private string userAnswer;
	private static CardRes currentCard;


	public AnswerChecker() { }
	
	public AnswerChecker(string solution, string userAnswer, CardRes currCard)
	{
		this.solution = solution;
		this.userAnswer = userAnswer;
		currentCard = currCard;
	}

	public static void ChangeCurrentCard(CardRes currCard) {
		currentCard = currCard;
	}


	public void SetSolutionAndStartCheck(string sol)
	{
		this.solution = sol;
		OnStartAnswerCheck();
	}

	public void SetUserAnswer(string answer)
	{
		this.userAnswer = answer;
		
	}

	public bool IsAnswerOK()
	{
		bool isOk = this.userAnswer == this.solution ? true : false;
		return isOk;
	}

	private void OnStartAnswerCheck()
	{
		if (IsAnswerOK()&& CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay() <= DeckHandle.GetCurrentCreateDeck()._cardList.Count-1)
		{
			GD.Print("Good Answer");
			//CurrentPlayDeckCardInformation.IncrementCurrentCardIndexInPlay();
			//CurrentPlayDeckCardInformation.SetCurrentCardInPlay(DeckHandle.GetCurrentCreateDeck()._cardList[CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay()]);
			CurrentPlayDeckCardInformation.SetIsCanChangeCard(true);
		}
		else if (IsAnswerOK() && CurrentPlayDeckCardInformation.GetCurrentCardIndexInPlay() ==
		         DeckHandle.GetCurrentCreateDeck()._cardList.Count-1)
		{
			CurrentPlayDeckCardInformation.SetIsCanChangeCard(false);
			GD.Print("Good answer but there is no more card in da deck");
		}
		else
		{
			CurrentPlayDeckCardInformation.SetIsCanChangeCard(false);
			GD.Print("Wrong Answer the answer is: " + CurrentPlayDeckCardInformation.GetCurrentCardInPlay().GetSolution());
		} 
	}

	public void ChangeCurrentVisibility()
	{
			
	}
}



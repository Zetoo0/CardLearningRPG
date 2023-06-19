using Godot;
using System;

public struct CurrentPlayDeckCardInformation
{
	private static CardRes currCardResInPlay;
	private static int currCardResIndexInPlay;
	private static bool IsCanChangeCard;

	public static bool GetIsCanChangeCard()
	{
		return IsCanChangeCard;
	}

	public static void SetIsCanChangeCard(bool state)
	{
		IsCanChangeCard = state;
	}
	
	public static CardRes GetCurrentCardInPlay() {
		return currCardResInPlay;
	}

	public static int GetCurrentCardIndexInPlay()
	{
		return currCardResIndexInPlay;
	}

	public static void IncrementCurrentCardIndexInPlay()
	{
		currCardResIndexInPlay++;
	}

	public static void SetCurrentCardIndexInPlayToZero()
	{
		currCardResIndexInPlay = 0;
	}

	public static void SetCurrentCardIndexInPlayTo(int number)
	{
		currCardResIndexInPlay = number;
	}

	public static void IncrementCurrentCardIndexInPlayWith(int number)
	{
		currCardResIndexInPlay += number;	
	}

	public static void SetCurrentCardInPlay(CardRes card)
	{
		currCardResInPlay = card;
	}

	public static void SetCurrentCardInPlaySolution(string sol)
	{
		currCardResInPlay.SetSolution(sol);
	}
}

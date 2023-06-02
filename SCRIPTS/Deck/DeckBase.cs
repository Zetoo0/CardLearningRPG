using Godot;
using System;

public abstract class DeckBase
{
	public abstract void AddCard(Card card);
	public abstract Card GetCard(string name);
	public abstract void Shuffle();


}

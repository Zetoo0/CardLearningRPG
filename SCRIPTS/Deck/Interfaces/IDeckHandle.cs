using Godot;
using System;

public interface IDeckHandle
{
	public static void CreateDeckResource() {
	 	new DeckRess();
	}

	public static DeckRess GetCurrentCreateDeck() {
		return new DeckRess();
	}

	public static void SetDeckRes(DeckRess deckRes) {
		GD.Print("SetDeckResource");
	}
	

}

using Godot;
using System;
using System.IO;

public interface IDeck
{
	public  void AddCard(ICard card);
	public  ICard GetCard(string name);
	public void Shuffle();
	public void AddCardToList(CardRes card);

	public static void SaveDeck(string deckName) {}

	public static void SaveDeckListToFile(string deckName, DeckRess deck){}//TODO add a choser and the user can switch between append and create

	public void WriteCardListToFile(ref StreamWriter sw_out);

    //Load the decklist
    public void LoadDeckListFromFile(string deckname) { }

    //Load the deck resour{}ce
    public static DeckRess LoadDeck(string namae)
    {
	    return new DeckRess();
    }


}

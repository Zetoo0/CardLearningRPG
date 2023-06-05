
using Godot;

public abstract class Card {
	public abstract string GetCardName();
	public abstract string GetSolution();
}



public abstract class JapaneseCardBase : Card
{
	public abstract string GetKanji();
	public abstract string GetRomaji();
	public abstract string GetKana();
	public abstract void SetKanji(string kanji);
	public abstract void SetKana(string kana);
	public abstract void SetRomaji(string romaji);
}


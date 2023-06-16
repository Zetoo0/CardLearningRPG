
using Godot;

public interface ICard {
	public string GetCardName();

	public string GetSolution();

	public string GetTask();
	
	public string[] GetMeanings();

	public string[] GetAdditionalInformations();

	public static void CreateAndAddCardToDaDeck(string task, string sol, string[] mean, string[] addInf = default) { }
};

	public interface IJapaneseCard : ICard
{
	public  string GetKanji();
	public  string GetRomaji();
	public  string GetKana();
	public  void SetKanji(string kanji);
	public  void SetKana(string kana);
	public  void SetRomaji(string romaji);
}


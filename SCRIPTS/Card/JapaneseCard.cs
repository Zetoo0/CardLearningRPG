using Godot;
using System;




public class JapaneseCard : JapaneseCardBase
{
	
	private string JP_Kanji;
	private string JP_Romaji;
	private string JP_Kana;
	private string[] means;
	private string cardName;

	public JapaneseCard(string task, string sol, string[] mean, string[] addInf = default) {
		//this.JP_Kana = "tesfghfgt";
		this.JP_Kanji = task;
		this.JP_Romaji = sol;
		this.cardName = "test11";
		this.means = mean;
	}
	
	public override string GetKanji()
	{
		return this.JP_Kanji;	
	}

	public override string GetRomaji()
	{
		return this.JP_Romaji;
	}

	public override string GetKana()
	{
		return this.JP_Kana;
	}

	public override void SetKanji(string kanji)
	{
		this.JP_Kanji = kanji;
	}

	public override void SetKana(string kana)
	{
		this.JP_Kana = kana;
	}

	public override void SetRomaji(string romaji)
	{
		this.JP_Romaji = romaji;
	}

	public override string GetCardName()
	{
		return this.JP_Kanji;
	}

	public override string GetSolution()
	{
		return this.JP_Romaji;
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return base.ToString();
	}
}



using Godot;
using System;
using System.Runtime.InteropServices;
using MonoCustomResourceRegistry;



[RegisteredType(nameof(CardRes))]
public partial class CardRes : Resource
{
     private string task;
     private string solution;
     private string[] meaning;
     private string[] additionalInformations;

    public CardRes(string task, string sol, string[] mean, string[] addInf = default)
    {

        this.task = task;
        this.solution = sol;
        this.meaning = mean;
        this.additionalInformations = addInf;
    }

    public CardRes()
    {
        this.task = "kanji";
        this.solution = "romaji";
    }

    public string GetTask()
    {
        return this.task;
    }

    public string GetSolution()
    {
        return this.solution;
    }

    public string[] GetMeanings() {
        return this.meaning;
    }

    public string[] GetAdditionalInformations() {
        return this.additionalInformations;
    }
    
    public static void CreateAndAddCardToDaDeck(string task, string sol, string[] mean, string[] addInf = default)
    {
        CardRes? cardRes = new CardRes(task, sol, mean, addInf);
        
        DeckHandle.GetCurrentCreateDeck().AddCardToList(cardRes);
    }
    
    
    
}

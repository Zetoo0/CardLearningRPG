using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using MonoCustomResourceRegistry;
using FileAccess = System.IO.FileAccess;

[RegisteredType(nameof(DeckRess))]
public partial class DeckRess : Resource
{
    public List<CardRes> _cardList;

    public DeckRess()
    {
        
        _cardList = new List<CardRes>();
      
    }
    
    public void AddCardToList(CardRes card)
    {
   
        string[] fasz = { "yes", "yno" };
       
        this._cardList.Add(card);
       
        GD.Print("added card romaji: " + _cardList[0].GetSolution());
       
    }
    
//Save the deck resource to a res file and the decklist into a csv
    public static void SaveDeck(string deckName)
    {
        //TODO CardRes getters
        
        GD.Print("Nefpre CARDLIST: "+ DeckHandle.GetCurrentCreateDeck()._cardList.Count);
       
        SaveDeckListToFile(deckName, DeckHandle.GetCurrentCreateDeck());
        
         Error err = ResourceSaver.Save(DeckHandle.GetCurrentCreateDeck(),path: "res://SavedDeckRes/test1.tres",ResourceSaver.SaverFlags.None); 
         if(!(err == Error.Ok)) GD.Print("There is a problem in da foooorce :')");
         
         DeckRess mashita = LoadDeck(deckName);
        
    }

    //Save the cardlist data to file, for the new loaded resource cardlist 
    public static void SaveDeckListToFile(string deckName, DeckRess deck)//TODO add a choser and the user can switch between append and create
    {
        FileStream fileStream = new FileStream("C:\\Users\\PC\\" + deckName + ".csv", FileMode.Create);
        StreamWriter sw_out = new StreamWriter(fileStream);
        
         deck.WriteCardListToFile(ref sw_out);
         
    }

    public void WriteCardListToFile(ref StreamWriter sw_out)
    {
        foreach (var card in this._cardList)
        {
            sw_out.Write(card.GetTask()+";"+card.GetSolution()+";");
            foreach (var meaning in card.GetMeanings())
            {
                sw_out.Write(meaning + ",");
            }
            sw_out.Write('\n'); 
        }
        
        sw_out.Flush();
        sw_out.Close();
    }

    //Load the decklist
    public void LoadDeckListFromFile(string deckname)
    {
        FileStream fileStream = new FileStream("C:\\Users\\PC\\" + deckname + ".csv", FileMode.Open);
        StreamReader sr_in = new StreamReader(fileStream);
        
        string _line;
        while ((_line = sr_in.ReadLine()) != null)
        {
            string[] splittedS = _line.Split(';');
            string[] splittedMeanings = splittedS[2].Split(',');
            this._cardList.Add(new CardRes(splittedS[0],splittedS[1],splittedMeanings));
        }
        sr_in.Close();

    }
 
    //Load the deck resource
    public static DeckRess LoadDeck(string namae)
    {
            var a = ResourceLoader.Load<DeckRess>("res://SavedDeckRes/test1.tres","_cardList",ResourceLoader.CacheMode.Reuse);
           a.LoadDeckListFromFile(namae);
           GD.Print("newgec: " + a._cardList[0].GetMeanings()[1]);
           
           return a;
    }


}

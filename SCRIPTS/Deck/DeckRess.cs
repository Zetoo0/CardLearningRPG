using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using Godot.Collections;
using MonoCustomResourceRegistry;
using FileAccess = System.IO.FileAccess;

[RegisteredType(nameof(DeckRess))]
public partial class DeckRess : Resource, IDeck//TODO Implements IDeck elkészítése
{
    public List<CardRes> _cardList;

    public DeckRess()
    {
        
        _cardList = new List<CardRes>();
      
    }

    public void AddCard(ICard card)
    {
        throw new NotImplementedException();
    }

    public ICard GetCard(string name)
    {
        throw new NotImplementedException();
    }

    public void Shuffle()
    {
        throw new NotImplementedException();
    }

    public void AddCardToList(CardRes card)
    {
        
        this._cardList.Add(card);
       
      //  GD.Print("added card romaji: " + _cardList[0].GetSolution());
       
    }
    
//Save the deck resource to a res file and the decklist into a csv
    public static void SaveDeck(string deckName)
    {
        //TODO CardRes getters
        
        GD.Print("Nefpre CARDLIST: "+ DeckHandle.GetCurrentCreateDeck()._cardList.Count);
       
        SaveDeckListToFile(deckName, DeckHandle.GetCurrentCreateDeck());
        
         Error err = ResourceSaver.Save(DeckHandle.GetCurrentCreateDeck(),path: "res://SavedDeckRes/"+deckName+".tres",ResourceSaver.SaverFlags.None);
         if (!(err == Error.Ok))
             PopupWin.PopupText("ERROR","Save Failed"); //GD.Print("There is a problem in da foooorce :')");
         else
         {
             PopupWin.PopupText("Success","Successfully saved!");
         }
         //DeckRess mashita = LoadDeck(deckName);

    }
    
/// <summary>
/// Save the cardlist data to file, for the new loaded resource cardlist
/// </summary>
/// <param name="deckName"></param>
/// <param name="deck"></param>
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

    /// <summary>
    /// Loads the decklist
    /// </summary>
    /// <param name="deckname"></param>
    public void LoadDeckListFromFile(string deckname)
    {
        FileStream fileStream = new FileStream("C:\\Users\\PC\\" + deckname + ".csv", FileMode.Open);
        StreamReader sr_in = new StreamReader(fileStream);
        
        string _line;
        while ((_line = sr_in.ReadLine()) != null)
        {
            this._cardList.Add(LoadCardFromReadFile(_line));
        }
        sr_in.Close();

    }

    /// <summary>
    /// Create a card resource from the current read line
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private CardRes LoadCardFromReadFile(string line)
    {
        string[] splittedS = line.Split(';');
        string[] splittedMeanings = splittedS[2].Split(',');
        CardRes retCard = new CardRes(splittedS[0], splittedS[1], splittedMeanings);
        return retCard;
    }

    /// <summary>
    ///  Loads the deck resource
    /// </summary>
    /// <param name="namae"></param>
    /// <returns>DeckRess</returns>
    public static void LoadDeck(string namae)
    {
        string[] fileName = namae.Split('.');
        GD.Print(fileName[0]);
        try
        {
            var a = ResourceLoader.Load<DeckRess>("res://SavedDeckRes/" + fileName[0] + ".tres", "_cardList",
                ResourceLoader.CacheMode.Reuse);
            a.LoadDeckListFromFile(fileName[0]);
            GD.Print("newgec: " + a._cardList[0].GetMeanings()[1]);
            DeckHandle.CreateDeckResource();
            DeckHandle.SetDeckRes(a);
            PopupWin.PopupText("Success","Deck successfully loaded!");    
        }
        catch (IOException e)
        {
            PopupWin.PopupText("ERROR","There was an error while loading");
        }
        

           //return a;
    }

    /// <summary>
    /// Get the saved decks name
    /// </summary>
    /// <param name="path"></param>
    /// <returns>string array</returns>
    public static String[] LoadDecksNameForItemList(string path)
    {
        //later directory handler?

        using var dir = DirAccess.Open(path);
        string[] decksNamae = dir.GetFiles();
        return decksNamae;
    }


}

using Godot;
using System;
using System.Collections.Generic;

public class CardResList
{
    private List<CardRes> _cardResList;

    public CardResList()
    {
        _cardResList = new List<CardRes>();
    }
    public List<CardRes> GetCardResList()
    {
        return this._cardResList;
    }

}
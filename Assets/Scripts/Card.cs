//Authored by Thomas Landry
//represents a playing card in a deck of cards

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card 
{
    protected int Value;
    protected String Name;
    protected String Suit;
    protected String Color;
    protected List<String> spawnEffects = new List<String>(); //these properties are for an expansion of the card buff system to allow effects when cards...
    protected List<String> hitEffects = new List<String>(); //... hit an enemy, are first created and more complex damage buffs. These are not...
    protected List<String> buffEffects = new List<String>(); //... implimented in the current build.
    protected String cardType = "Card";

    public Card(String name, String suit, String color, int value, List<String> buffEffect, List<String> hitEffect, List<String> spawnEffect)
    {
        this.Value = value;
        this.Name = name;
        this.Suit = suit;
        this.Color = color;
        this.spawnEffects = spawnEffect;
        this.hitEffects = hitEffect;
        this.buffEffects = buffEffect;
    }

    public string getCardType() //returns whether the card is a normal card or a tarot card(unimplemented)
    {
        return cardType;
    }

    public string getCardName() 
    {
        return Name;
    }
    
    public string getCardSuit()
    {
        return Suit;
    }

    public int getCardValue()
    {
        return Value;
    }
    public string getColor()
    {
        return Color;
    }

    internal int buffDamage() //returns the damage buff to other cards
    {
        if (getCardValue()<= 10)
            return getCardValue();
        else
            return 0;
    }

    internal string getBuff() //returns the utility buffs of a card
    {
        if (getCardValue() >= 11)
        {
            return null;//buffEffects[0];
        }
        else
            return null;
    }
}
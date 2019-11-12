//Authored by Thomas Landry
//this script represent the deck of cards that the player character uses
//as ammunition. The objective was to as closely emulate a real deck of
//fifty-two playing cards as possible.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckofCards : MonoBehaviour {
    private List<Card> Deck = new List<Card>(); //cards in the deck
    private List<Card> Discard = new List<Card>(); //casrds in the discard pile
    private Card[] BuffCards = new Card[3]; //cards buffing the current deck of cards
    private Card[] HeldCards = new Card[3]; //cards reserved to buff the next deck of cards

	// Use this for initialization
	void Start () {

        InitializeDeck();
        
	}

    private void InitializeDeck() //creates the individual cards, adds them to the deck and shuffles
    {
        //this initiallizes the deck of 52 standard playing cards
        string name = "";
        int value = 0;
        string suit = "";
        string color = "";
        List<String> hitEffects = new List<String>(); //these properties are for an expansion of the card buff system to allow effects when cards...
        List<String> spawnEffects = new List<String>(); //... hit an enemy, are first created and more complex damage buffs. These are not...
        List<String> buffEffects = new List<String>(); //... implimented in the current build.
        for (int i = 0; i <= 3; i++)//this represents suit  
        {
            for (int j = 1; j <= 13; j++)//this represents the number of the card
            {
                value = j;

                //picks suit based on i value
                if (i == 0)
                {
                    suit = "Spades";
                    color = "Black";
                }
                else if (i == 1)
                {
                    suit = "Clubs";
                    color = "Black";
                }
                else if (i == 2)
                {
                    suit = "Diamonds";
                    color = "Red";
                }
                else if (i == 3)
                {
                    suit = "Hearts";
                    color = "Red";
                }

                //creates unique names for the face cards
                if (j <= 10)
                    name = j.ToString() + " of " + suit;
                else if (j == 11)
                    name = "Jack" + " of " + suit;
                else if (j == 12)
                    name = "Queen" + " of " + suit;
                else if (j == 13)
                    name = "King" + " of " + suit;

                //this will assign buffs to the cards face cards, currently unimplimented
                if (name == "Jack of Spades" || name == "Jack of Clubs")
                {
                    
                    
                }
                if (name == "Jack of Diamonds" || name == "Jack of Hearts")
                {


                }
                if (name == "Queen of Spades" || name == "Queen of Clubs")
                {


                }
                if (name == "Queen of Diamonds" || name == "Queen of Hearts")
                {


                }
                if (name == "King of Spades" || name == "King of Clubs")
                {


                }
                if (name == "King of Diamonds" || name == "King of Hearts")
                {


                }

                Deck.Add(new Card(name, suit, color, value, buffEffects, hitEffects, spawnEffects));

            }
        }
        
        Shuffle(); //randomizes the cards in an innitial shuffle
        Shuffle(); //because the shuffle emulates a physical action, calling shuffle twice ensures a... 
        //... better random distribution.
        
    }

    public void Shuffle() //shuffles the deck and discard pile back intot he deck along with buff cards, moves held cards to buff cards.
    {
        foreach (Card card in Deck)
        {
            Discard.Add(card); 
        }
        Deck.Clear();
        foreach (Card card in BuffCards)//moves buff cards to discard
        {
            if (card != null)
            {
                if (card.getCardType() != "Tarot") //this takes care of the unique behaviour outlined for tarot cards which are not implemented in the current build
                    Discard.Add(card);
            }
        }
        for (int i = 0; i <= 2; i++)//moves held cards to buff cards
        {
            BuffCards[i] = HeldCards[i];
            HeldCards[i] = null;
        }

        while (Discard.Count >= 1)//this continuously picks a random card fromt he discard pile and adds it to the deck to simulate a shuffle
        {
            int i = UnityEngine.Random.Range(0, Discard.Count);
            Deck.Add(Discard[i]);
            Discard.RemoveAt(i);
        }

        print("Shuffle");

    }

    public string getCardAtN(int n) //returns the name of the card at position n in the deck if such a card exists
    {
        if (Deck.Count >= n)
            return Deck[n].getCardName();
        else
            return null;
    }

    public Card getCardN(int n)
    {
        if (Deck.Count >= n)
        {
            return Deck[n];
        }
        else
        {
            return null;
        }
    }

    public int getDeckSize()
    {
        return Deck.Count;
    }

    public int getNextDamage() //returns the full damage of the card at the top of the deck including buffs
    {
        int totalDamage = 0;
        if (getDeckSize() > 0)
        {
            foreach (Card card in BuffCards) //cycles through the buff cards for relevent damage increases, cards of the same color get buffed (i.e. black buffs black, red buffs red, tarot cards buff all cards)
            {
                if ((card != null) && ((Deck[0].getColor().Equals(card.getColor())))) // || (card.getCardType().Equals("Tarot")))))
                {
                    totalDamage += card.buffDamage();
                    print(totalDamage);
                }
                
            }
            return (Deck[0].getCardValue() + totalDamage); //returns the damage 
        }
        else
        {
            return -1; //for cases where the deck is empty, should not show up
        }
    }

    public Card getBuffCard(int n)
    {
        if (BuffCards[n] != null && n <= 2)
        {
            return BuffCards[n];
        }
        else
        {
            return null;
        }
        
    }

    public Card getHeldCard(int n)
    {
        if (HeldCards[n] != null && n <= 2)
        {
            return HeldCards[n];
        }
        else
        {
            return null;
        }
    }
    public List<string> getNextBuffs() //returns the utility buffs for the top card (color matching still applies) 
    {
        List<string> totalBuffs = new List<string>();
        if (Deck[0] != null)
        {
            foreach (Card card in BuffCards)
            {
                if ((card != null) && ((Deck[0].getColor().Equals(card.getColor()) || (card.getCardType().Equals("Tarot")))))
                {
                    totalBuffs.Add(card.getBuff());
                }
                
            }
            totalBuffs.Add(Deck[0].getBuff());
            return totalBuffs;
        }
        else
            return null;
    }

    public void discard() //cycles the top card for when a card is fired
    {
        Discard.Add(Deck[0]);
        Deck.RemoveAt(0);
    }

    public string holdCard() //moves the top card to the held card zone if there is room
    {
        if (Deck.Count > 0)
        {
            if (HeldCards[0] == null)
            {
                HeldCards[0] = Deck[0];
                Deck.RemoveAt(0);
                return HeldCards[0].getCardName();
            }
            else if (HeldCards[1] == null)
            {
                HeldCards[1] = Deck[0];
                Deck.RemoveAt(0);
                return HeldCards[1].getCardName();
            }
            else if (HeldCards[2] == null)
            {
                HeldCards[2] = Deck[0];
                Deck.RemoveAt(0);
                return HeldCards[2].getCardName();
            }
            else
            {
                return "Held cards full";
            }

        }
        else
            return "Deck Empty";
    }
}

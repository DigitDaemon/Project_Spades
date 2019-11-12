using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDeckOfCards : MonoBehaviour {
    private string[,] Cards; //[x,0] number, [x,1] name, [x,2] suit, [x,3] buff, [x,4] color, [x,5] display symbol
    private List<int> Deck;
    private int DeckPointer;
    private int CreationPointer;
    private Stack<int> Hand1;
    private Stack<int> Hand2;
    private int[] HeldCards;
    private int[] BuffCards;
    // Use this for initialization
    void Start () {
        //print("Start NewDeckOfCards");
        BuffCards = new int[3] {-1, -1, -1};
        HeldCards = new int[3] {-1, -1, -1};
        DeckPointer = 0;
        CreationPointer = 0;
        Hand1 = new Stack<int>();
        Hand2 = new Stack<int>();
        InitializeCards();
        InitializeDeck();

	}

    private void InitializeCards()
    {
        Cards = new string[54, 6];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                Cards[CreationPointer, 0] = j.ToString();



                if (i == 0)
                {
                    Cards[CreationPointer, 2] = "Spades";
                    Cards[CreationPointer, 4] = "Black";
                }
                else if (i == 1)
                {
                    Cards[CreationPointer, 2] = "Clubs";
                    Cards[CreationPointer, 4] = "Black";
                }
                else if (i == 2)
                {
                    Cards[CreationPointer, 2] = "Diamonds";
                    Cards[CreationPointer, 4] = "Red";
                }
                else if (i == 3)
                {
                    Cards[CreationPointer, 2] = "Hearts";
                    Cards[CreationPointer, 4] = "Red";
                }

                if (j < 11 && j > 1)
                {
                    Cards[CreationPointer, 1] = j.ToString() + " of " + Cards[CreationPointer, 2];
                    Cards[CreationPointer, 5] = j.ToString();
                }
                else if (j == 1)
                {
                    Cards[CreationPointer, 1] = "Ace" + " of " + Cards[CreationPointer, 2];
                    Cards[CreationPointer, 5] = "A";
                }
                else if (j == 11)
                {
                    Cards[CreationPointer, 1] = "Jack" + " of " + Cards[CreationPointer, 2];
                    Cards[CreationPointer, 5] = "J";
                }
                else if (j == 12)
                {
                    Cards[CreationPointer, 1] = "Queen" + " of " + Cards[CreationPointer, 2];
                    Cards[CreationPointer, 5] = "Q";
                }
                else if (j == 13)
                {
                    Cards[CreationPointer, 1] = "King" + " of " + Cards[CreationPointer, 2];
                    Cards[CreationPointer, 5] = "K";
                }

                //print(CreationPointer);
                //print(Cards[CreationPointer, 1] + " of " + Cards[CreationPointer, 2]);
                if (j == 11)
                {
                    if (i == 0)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 1)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 2)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 3)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                }
                else if (j == 12)
                {
                    if (i == 0)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 1)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 2)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 3)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                }
                else if (j == 13)
                {
                    if (i == 0)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 1)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 2)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                    if (i == 3)
                    {
                        Cards[CreationPointer, 3] = "";
                    }
                }

                CreationPointer++;

                
            }
        }

        for (int i = 0; i < 2; i++)
        {
            Cards[CreationPointer, 0] = "0";
            Cards[CreationPointer, 1] = "Joker";
            Cards[CreationPointer, 2] = "Special";
            Cards[CreationPointer, 3] = "Crit";
            Cards[CreationPointer, 4] = "";
            Cards[CreationPointer, 5] = "Jo";
            CreationPointer++;
        }
        
    }
    private void InitializeDeck()
    {
        Deck = new List<int>();
        for (int i =0; i < 54; i++)
        {
            Deck.Add(i);
            //print(i);
            //print(Deck[Deck.Count - 1].ToString());
        }

        Shuffle();
        Shuffle();
    }
    public void Shuffle()
    {
        //print("Shuffle Start");
        
        for (int i = 0; i < 3; i++)
        {
            if (BuffCards[i] != -1)
            {
                if (BuffCards[i] < 54)
                    Deck.Add(BuffCards[i]);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            BuffCards[i] = HeldCards[i];
            HeldCards[i] = -1;
        }
        for (int i = 0; i < ((int)Deck.Count/2); i++)
        {
            Hand1.Push(Deck[0]);
            Deck.RemoveAt(0);
        }
        while (Deck.Count != 0)
        {
            Hand2.Push(Deck[0]);
            Deck.RemoveAt(0);
        }

        while(Hand1.Count != 0 || Hand2.Count != 0)
        {
            if(Hand1.Count >= 3)
            {
                for (int i = 0; i < UnityEngine.Random.Range(1,3) ; i++)
                {
                    Deck.Add(Hand1.Pop());
                }
            }
            else if (Hand1.Count >= 2)
            {
                for (int i = 0; i < UnityEngine.Random.Range(1, 2) ; i++)
                {
                    Deck.Add(Hand1.Pop());
                }
            }
            else if (Hand1.Count >= 1)
            {
                Deck.Add(Hand1.Pop());
            }

            if (Hand2.Count >= 3)
            {
                for (int i = 0; i < UnityEngine.Random.Range(1, 3); i++)
                {
                    Deck.Add(Hand2.Pop());
                }
            }
            else if (Hand2.Count >= 2)
            {
                for (int i = 0; i < UnityEngine.Random.Range(1, 2); i++)
                {
                    Deck.Add(Hand2.Pop());
                }
            }
            else if (Hand2.Count >= 1)
            {
                Deck.Add(Hand2.Pop());
            }
        }

        DeckPointer = 0;
        //print("shuffle end");
    }

    public string[] getCardN(int n)
    {
        if ((DeckPointer + n) < Deck.Count)
            return new string[] { Cards[Deck[DeckPointer + n], 0], Cards[Deck[DeckPointer + n], 1], Cards[Deck[DeckPointer + n], 2], Cards[Deck[DeckPointer + n], 3], Cards[Deck[DeckPointer + n], 4], Cards[Deck[DeckPointer + n], 5] };
        else
            return null;
    }

    public string getCardAtN(int n)
    {
        if (getDeckSize() > 0)
        {
            return Cards[Deck[DeckPointer + n], 1];
        }
        else
            return null;
    }

    public int getDeckSize()
    {
        if (DeckPointer >= 0)
            return (Deck.Count - DeckPointer) + 1;
        else
            return 0;
    }

    public void Discard()
    {
        if ((Deck.Count - DeckPointer) > 0)
        {
            DeckPointer++;
        }
        else if((Deck.Count - DeckPointer) == 0)
        {
            DeckPointer = -1;
        }
        else if (DeckPointer == -1)
        {
            //might need this
        }
    }

    public int getNextDamage()
    {
        int totalDamage = 0;

        if (getDeckSize() > 0)
        {
            foreach (int card in BuffCards) //cycles through the buff cards for relevent damage increases, cards of the same color get buffed (i.e. black buffs black, red buffs red, tarot cards buff all cards)
            {
                if (((card != -1) && (Cards[Deck[DeckPointer], 4] == Cards[card, 4])) && Int32.Parse(Cards[card, 0]) < 11)  // || (card.getCardType().Equals("Tarot")))))
                {
                    totalDamage += Int32.Parse(Cards[card, 0]);
                    print(totalDamage);
                }

            }
            return (Int32.Parse(Cards[Deck[DeckPointer], 0]) + totalDamage);
        }
        else
            return -1;
    }
    public string[] getNextBuffs()
    {
        string[] buffs = new string[4];
        if (getDeckSize() > 0)
        {
            for (int i = 0; i < 3; i++) //cycles through the buff cards for relevent damage increases, cards of the same color get buffed (i.e. black buffs black, red buffs red, tarot cards buff all cards)
            {
                if ((BuffCards[i] != -1) && ((Cards[Deck[DeckPointer], 4] == Cards[BuffCards[i], 4]) || (Cards[BuffCards[i], 4] == "Special"))) // || (card.getCardType().Equals("Tarot")))))
                {
                    buffs[i] = Cards[BuffCards[i], 3];
                }
                else
                    buffs[i] = "";
            }
            if (Cards[DeckPointer, 4] == "Secial")
                buffs[3] = Cards[DeckPointer, 3];
            else
                buffs[3] = "";
            return buffs;
        }
        else
            return null;
    }
    public string[] getBuffCard(int n)
    {
        if (BuffCards[n] != -1 && n <= 2)
        {
            return new string[] { Cards[BuffCards[n], 0], Cards[BuffCards[n], 1], Cards[BuffCards[n], 2], Cards[BuffCards[n], 3], Cards[BuffCards[n], 4], Cards[BuffCards[n], 5] };
        }
        else
        {
            return null;
        }
    }
    public string[] getHeldCard(int n)
    {
        if (HeldCards[n] != -1 && n <= 2)
        {
            return new string[] { Cards[HeldCards[n], 0], Cards[HeldCards[n], 1], Cards[HeldCards[n], 2], Cards[HeldCards[n], 3], Cards[HeldCards[n], 4], Cards[HeldCards[n], 5] };
        }
        else
        {
            return null;
        }
    }
    public string holdCard()
    {
        if (getDeckSize() > 0)
        {
            if (HeldCards[0] == -1)
            {
                HeldCards[0] = Deck[0];
                Deck.RemoveAt(0);
                return Cards[HeldCards[0],1];
            }
            else if (HeldCards[1] == -1)
            {
                HeldCards[1] = Deck[0];
                Deck.RemoveAt(0);
                return Cards[HeldCards[0], 1];
            }
            else if (HeldCards[2] == -1)
            {
                HeldCards[2] = Deck[0];
                Deck.RemoveAt(0);
                return Cards[HeldCards[0], 1];
            }
            else
            {
                return "Held cards full";
            }

        }
        else
            return "Deck Empty";
    }
    // Update is called once per frame
    void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public NewDeckOfCards Deck;
    public RawImage[] BuffBack;
    public Text[] BuffText;
    public RawImage[] HeldBack;
    public Text[] HeldText;
    public RawImage[] UpNextBack;
    public Text[] UpNextText;
    public Texture[] BackgroundTexture;
    public Text Count;
    public Text LifeCounter;
    public PlayerLife playerLife;
	// Use this for initialization
	void Start () {
        UpdateBuffHeld();
        UpdateCount();
        UpdateUpNext();
	}
    public void UpdateLife()
    {
        LifeCounter.text = playerLife.getLife().ToString() + "/100";
    }
    public void UpdateCount()
    {
        Count.text = Deck.getDeckSize().ToString();
    }
    public void UpdateUpNext()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Deck.getDeckSize() >= i+1)
            {
                if (Deck.getCardN(i)[2].Equals("Spades"))
                {
                    UpNextBack[i].texture = BackgroundTexture[0];
                }
                else if (Deck.getCardN(i)[2].Equals("Clubs"))
                {
                    UpNextBack[i].texture = BackgroundTexture[1];

                }
                else if (Deck.getCardN(i)[2].Equals("Diamonds"))
                {
                    UpNextBack[i].texture = BackgroundTexture[2];
                }
                else if (Deck.getCardN(i)[2].Equals("Hearts"))
                {
                    UpNextBack[i].texture = BackgroundTexture[3];
                }
                else if (Deck.getCardN(i)[2].Equals("Special"))
                {
                    UpNextBack[i].texture = BackgroundTexture[4];
                }
                    UpNextText[i].text = Deck.getCardN(i)[5];
            }
            else
            {
                UpNextText[i].text = "";
                UpNextBack[i].texture = BackgroundTexture[4];
            }

        }

    }
    public void UpdateBuffHeld()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Deck.getHeldCard(i) != null)
            {
                if (Deck.getHeldCard(i)[2].Equals("Spades"))
                {
                    HeldBack[i].texture = BackgroundTexture[0];
                }
                else if (Deck.getHeldCard(i)[2].Equals("Clubs"))
                {
                    HeldBack[i].texture = BackgroundTexture[1];
                }
                else if (Deck.getHeldCard(i)[2].Equals("Diamonds"))
                {
                    HeldBack[i].texture = BackgroundTexture[2];
                }
                else if (Deck.getHeldCard(i)[2].Equals("Hearts"))
                {
                    HeldBack[i].texture = BackgroundTexture[3];
                }
                else if (Deck.getHeldCard(i)[2].Equals("Special"))
                {
                    HeldBack[i].texture = BackgroundTexture[4];
                }
                HeldText[i].text = Deck.getHeldCard(i)[5];
            }
            else
            {
                HeldText[i].text = "";
                HeldBack[i].texture = BackgroundTexture[4];
            }

            if (Deck.getBuffCard(i) != null)
            {
                if (Deck.getBuffCard(i)[2].Equals("Spades"))
                {
                    BuffBack[i].texture = BackgroundTexture[0];
                }
                else if (Deck.getBuffCard(i)[2].Equals("Clubs"))
                {
                    BuffBack[i].texture = BackgroundTexture[1];
                }
                else if (Deck.getBuffCard(i)[2].Equals("Diamonds"))
                {
                    BuffBack[i].texture = BackgroundTexture[2];
                }
                else if (Deck.getBuffCard(i)[2].Equals("Hearts"))
                {
                    BuffBack[i].texture = BackgroundTexture[3];
                 }
                else if (Deck.getBuffCard(i)[2].Equals("Special"))
                {
                    BuffBack[i].texture = BackgroundTexture[4];
                }
                BuffText[i].text = Deck.getBuffCard(i)[5];
            }
            else
            {
                BuffText[i].text = "";
                BuffBack[i].texture = BackgroundTexture[4];
            }

        }
    }
	// Update is called once per frame
	void Update () {
        UpdateUpNext();
        UpdateCount();
        UpdateBuffHeld();
        UpdateLife();
	}
}

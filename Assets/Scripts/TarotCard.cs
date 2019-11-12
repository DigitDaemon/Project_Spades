using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TarotCard : Card
{

    public TarotCard(String name, String suit, String color, int value, List<String> buffEffect, List<String> hitEffect, List<String> spawnEffect)
        : base(name, suit, color, value, buffEffect, hitEffect, spawnEffect)
    {  
        this.cardType = "Tarot";
    }

}

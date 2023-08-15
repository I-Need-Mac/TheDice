using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DeckPanel : MonoBehaviour
{
    public List<Dice> dicelist= new List<Dice>();
    public Deck deck;
    public DeckData deckdata;
    public List<DeckSlot> deckSlots= new List<DeckSlot>();
    public void AddDice(Dice dice)
    {
        if(dicelist.Count<=15)
        {
            deckdata.diceList.Add(dice);           
        }
        else if(dicelist.Count>15)
        {
            Debug.Log("µ¶¿Ã ¥Ÿ √°Ω¿¥œ¥Ÿ");
        }
        
    }
}

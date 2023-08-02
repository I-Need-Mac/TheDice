using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeckPanel : MonoBehaviour
{
    public Transform [] Slot = new Transform[15];   
    public List<Dice> dicelist= new List<Dice>();
    public Deck deck;
    public DeckData deckdata;

    public void AddDice(Dice dice)
    {
        if(dicelist.Count<=15)
        {
            dicelist.Add(dice);
        }
        else if(dicelist.Count>15)
        {
            Debug.Log("µ¶¿Ã ¥Ÿ √°Ω¿¥œ¥Ÿ");
        }
        
    }
}

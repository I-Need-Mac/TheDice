using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    [SerializeField]
    public List<Dice> diceList = new List<Dice>();
    [SerializeField]
    private Transform deck_position;
    [SerializeField]
    private DeckData deckdata;

    private Dice dice;
    private void Start()
    {
        diceList = deckdata.diceList;
        //for (int i = 0; i < diceList.Count; i++)
        //{
        //    dice = diceList[i];
        //    Instantiate(dice, deck_position);

        //}
    }
    private void Shuffle()
    {
        System.Random random = new System.Random();
        int n = diceList.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Dice value = diceList[k];
            diceList[k] = diceList[n];
            diceList[n] = value;
        }
    }
}
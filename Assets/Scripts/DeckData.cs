using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Custom/DiceData", order = 1)]
public class DeckData : ScriptableObject
{
    public List<Dice> diceList = new List<Dice>();
}


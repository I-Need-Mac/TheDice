using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    [SerializeField]
    public List<Dice> diceList = new List<Dice>();
    [SerializeField]
    private Transform DeckPosition;
    [SerializeField]
    private Transform DeckInit;
    [SerializeField]
    private Transform board;
    
    private int dicenum;

    private void Start()
    {
        for (int i = 0; i < DeckInit.childCount; i++)
        {
            Transform diceTransform = DeckInit.GetChild(i);
            Dice dice = diceTransform.GetComponent<Dice>();

            if (dice != null)
            {
                diceList.Add(dice);
            }
        }
        Shuffle();
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

    public void Rolling()
    {
        Debug.Log($"------------{GameManager.instance.turn}turn----------");
        //Player 01 Rest Roll
        if (GameManager.instance.Player01_Rest&&GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 5; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
            }
            GameManager.instance.Player01_Rest = false;
        }
        //Player 02 Rest Roll
        else if (GameManager.instance.Player02_Rest && !GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 5; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
            }
            GameManager.instance.Player02_Rest = false;
        }
        //Player 01 Powered Roll
        else if(GameManager.instance.Player01_PowerRolled&&GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 3; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
            }
            GameManager.instance.Player01_PowerRolled=false;
        }
        //Player02 Powered Roll
        else if (GameManager.instance.Player02_PowerRolled && !GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 3; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
            }
            GameManager.instance.Player02_PowerRolled = false;
        }
        //Nomal Roll
        else
        {
            for (int i = 0; i < 4; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
            }
        }
        GameManager.instance.Player01_turn = !GameManager.instance.Player01_turn;
        int DeckCount = diceList.Count;
        Debug.Log("Deck Count: "+DeckCount);
    }
    public void PowerRoll()
    {
        if(GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 6; i++)
            {
                diceList[i].transform.SetParent(board.transform);
                diceList[i].transform.localPosition = Vector3.zero;
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
                GameManager.instance.Player01_PowerRolled = true;
            }
            GameManager.instance.Player01_turn = !GameManager.instance.Player01_turn;
        }

        else if(!GameManager.instance.Player01_turn)
        {
            for (int i = 0; i < 6; i++)
            {
                diceList[i].transform.position = new Vector3(Random.Range(30.0f, 275), Random.Range(-25.0f, -100.0f));
                diceList[i].transform.SetParent(board);
                diceList[i].Roll();
                Dice dice = diceList[i];
                if (dice.Mark[dice.dicenum] != (int)DiceType.Reroll)
                {
                    diceList.Remove(diceList[i]);
                }
                else if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {

                }
                GameManager.instance.Player02_PowerRolled = true;
            }
            GameManager.instance.Player01_turn = !GameManager.instance.Player01_turn;
        }
        int DeckCount = diceList.Count;
        Debug.Log("Deck Count: " + DeckCount);
       
    }
}
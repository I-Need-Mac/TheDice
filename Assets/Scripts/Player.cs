using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 15;
    public int Shield = 0;
    public int Damage = 1;
    public bool Rest;
    public bool Power;
    public bool Turn;
    public int Rolling_Count;

    [SerializeField]
    private Deck deck;

    private Dice dice;

    [SerializeField]
    public Transform board;
    private void Start()
    {
        DeckEquip();
    }

    public void Rolling()
    {
        if(Power==true)
        {
            Debug.Log("지난턴에 파워롤을 했습니다");
        }
        if (Turn==true&&Power==false)
        {
            if (Rest == true)
            { 
                Rolling_Count = 5;
            }
            else
            {
                Rolling_Count = 4;
            }
            if(deck.diceList.Count<=Rolling_Count)
            {
                Rolling_Count=deck.diceList.Count;
            }
            //레스트api,소켓 통신
            for (int i = 0; i < Rolling_Count; i++)
            {
                    deck.diceList[i].transform.SetParent(board.transform);
                    deck.diceList[i].transform.localPosition = Vector3.zero;
                    deck.diceList[i].Roll();
                    dice = deck.diceList[i];
                    if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                    {
                        deck.diceList.Add(dice);
                    }
            }
            deck.diceList.RemoveRange(0, Rolling_Count);
            Rest = false;
            Power = false;
            GameManager.instance.TurnOver();
        }
    }
    public void PowerRoll()
    {
        Rolling_Count = 5;
        if (Rest == true)
        {
            Rolling_Count = 6;
        }
        if (Power==false&&Turn==true)
        {
            for (int i = 0; i < Rolling_Count; i++)
            {
                    deck.diceList[i].transform.SetParent(board.transform);
                    deck.diceList[i].transform.localPosition = Vector3.zero;
                    deck.diceList[i].Roll();
                    dice = deck.diceList[i];
                    Power = true;
                if (dice.Mark[dice.dicenum] == (int)DiceType.Reroll)
                {
                    deck.diceList.Add(dice);
                }
            }
            Debug.Log("남은 덱" + deck.diceList.Count);
            deck.diceList.RemoveRange(0, Rolling_Count);
        }
        else if(Power==true)
        {
            Debug.Log("지난 턴에 파워롤을 이미 했습니다!");
        }
        GameManager.instance.TurnOver();
    }
    public void RestTurn()
    {
        if(Rest==true)
        {
            Debug.Log("지난턴에 쉬었습니다");
        }
        else if(Rest == false)
        {
        Rest = true;
        GameManager.instance.TurnOver();
        }
    }

    private void DeckEquip()
    {
        if(gameObject.name=="Player01")
        {
            // 씬 내에 있는 "Deck" 태그를 가진 게임 오브젝트를 찾아서 할당
            GameObject deckObject = GameObject.FindWithTag("Player01_Deck");

            if (deckObject != null)
            {
                deck = deckObject.GetComponent<Deck>();
            }
            else
            {
                Debug.LogError("Could not find 'Deck' GameObject in the scene.");
            }
        }
        if (gameObject.name == "Player02")
        {
            // 씬 내에 있는 "Deck" 태그를 가진 게임 오브젝트를 찾아서 할당
            GameObject deckObject = GameObject.FindWithTag("Player02_Deck");

            if (deckObject != null)
            {
                deck = deckObject.GetComponent<Deck>();
            }
        }

    }
}



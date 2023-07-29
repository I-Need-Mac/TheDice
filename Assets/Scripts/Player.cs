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
            Debug.Log("�����Ͽ� �Ŀ����� �߽��ϴ�");
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
            //����Ʈapi,���� ���
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
            Debug.Log("���� ��" + deck.diceList.Count);
            deck.diceList.RemoveRange(0, Rolling_Count);
        }
        else if(Power==true)
        {
            Debug.Log("���� �Ͽ� �Ŀ����� �̹� �߽��ϴ�!");
        }
        GameManager.instance.TurnOver();
    }
    public void RestTurn()
    {
        if(Rest==true)
        {
            Debug.Log("�����Ͽ� �������ϴ�");
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
            // �� ���� �ִ� "Deck" �±׸� ���� ���� ������Ʈ�� ã�Ƽ� �Ҵ�
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
            // �� ���� �ִ� "Deck" �±׸� ���� ���� ������Ʈ�� ã�Ƽ� �Ҵ�
            GameObject deckObject = GameObject.FindWithTag("Player02_Deck");

            if (deckObject != null)
            {
                deck = deckObject.GetComponent<Deck>();
            }
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Hp = 15;
    public int Shield = 0;
    public int Damage = 1;
    
    private bool Rest;
    private bool Power;

    public bool isRoll=false;
    public bool isRest=false;
    public bool isPower=false;
    public bool ischoice=false;

    private int Rolling_Count;
    private Dice dice;

    [SerializeField]
    private Deck deck;
    [SerializeField]
    private Transform board;
    [SerializeField]
    private Player OtherPlayer;

    [SerializeField]
    public Button Rolling_Button;
    [SerializeField]
    public Button Power_Button;
    [SerializeField]
    public Button Rest_Button;
    private void Start()
    {
        Rolling_Count = 4;
        DeckEquip();
    }

    public void Rolling()
    {
        DisableAllButtons(false);
        ischoice = true;
        isRoll= true;
        
    }
    public void PowerRoll()
    {
        DisableAllButtons(false);
        ischoice = true;
        isPower= true;
    }
    public void RestTurn()
    {
        DisableAllButtons(false);
        ischoice = true;
        isRest = true;
    }


    public void PlayerAction()
    {
        if(isRoll == true)
        {
            if (Power == true)
            {
                Debug.Log("지난턴에 파워롤을 했습니다");
            }
            else
            {
                if (deck.diceList.Count <= Rolling_Count)
                {
                    Rolling_Count = deck.diceList.Count;
                }
                for (int i = 0; i < Rolling_Count; i++)
                {
                    dice = deck.diceList[i];
                    Instantiate(deck.diceList[i],board);
                    deck.diceList[i].Roll();
                }
                deck.diceList.RemoveRange(0, Rolling_Count);
                if (Rest == true)
                {
                    Rest = false;
                    Rolling_Count--;
                }
                Power = false;
            }
        }
        if(isPower == true)
        {
            ++Rolling_Count;
            if (Power == false)
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
            else if (Power == true)
            {
                Debug.Log("지난 턴에 파워롤을 이미 했습니다!");
            }
            Rolling_Count--;
        }
        if(isRest == true)
        {
            if (Rest == true)
            {
                Debug.Log("지난턴에 쉬었습니다");
            }
            else if (Rest == false)
            {
                Rest = true;
                Rolling_Count++;
            }
        }
    }

    public void Attack()
    {
        if (OtherPlayer.Shield >= 1)
        {
            OtherPlayer.Shield -= 1;
        }
        else
        {
            OtherPlayer.Hp -= 1;
        }
    }
    public void Shield_UP()
    {
        Shield += 1;
    }
    public void SelfDamaged()
    {
        if (Shield >= 1)
        {
            Shield -= 1;
        }
        else
        {
            Hp -= 1;
        }
    }

    public void DisableAllButtons(bool isDisable)
    {
        Rolling_Button.interactable = isDisable;
        Power_Button.interactable = isDisable;
        Rest_Button.interactable = isDisable;
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



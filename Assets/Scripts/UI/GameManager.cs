using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Deck deck;

    #region Field
    public int Player_Hp = 15;
    public int Enemy_Hp = 15;
    public int Player_Shield = 0;
    public int Enemy_Shield = 0;
    public int turn = 1;
    public bool Player01_turn;

    public bool Player01_Rest;
    public bool Player02_Rest;
    public bool Player01_PowerRolled;
    public bool Player02_PowerRolled;
    #endregion

    #region SerializeField
         #region text
    [SerializeField]
    private Text Turn;
    [SerializeField]
    private Text Player_HP_txt;
    [SerializeField]
    private Text Enemy_HP_txt;
    [SerializeField]
    private Text Player_Shield_txt;
    [SerializeField]
    private Text Enemy_Shield_txt;
    [SerializeField]
    private Text Player_Vic_txt;
    [SerializeField]
    private Text Enemy_Vic_txt;
    [SerializeField]
    private Text Player01_DeckCount;
    [SerializeField]
    private Text Player02_DeckCount;
    [SerializeField]
    private Text Victory_txt;
    [SerializeField]
    private Text Defeat_text;
    #endregion text
         #region button
    [SerializeField]
    private Button Player_Button;
    [SerializeField]
    private Button Enemy_Button;
    [SerializeField]
    private Button Player01_Rest_Button;
    [SerializeField]
    private Button Player02_Rest_Button;
    [SerializeField]
    private Button Player01_PowerRoll_Button;
    [SerializeField]
    private Button Player02_PowerRoll_Button;
    #endregion
    #endregion

    static public GameManager instance;

    private void Awake()
    {
        
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    private void Start()
    {
        Player01_turn = true;
        Enemy_Button.interactable = false;
        Player02_Rest_Button.interactable = false;
        Player02_PowerRoll_Button.interactable = false;
    }

    private void Update()
    {
        Turn.text = $"Turn: {turn}";
        Player_HP_txt.text = $"HP: {Player_Hp}";
        Enemy_HP_txt.text = $"HP: {Enemy_Hp}";
        Player_Shield_txt.text = $"Shield : {Player_Shield}";
        Enemy_Shield_txt.text = $"Shield : {Enemy_Shield}";

        GameOver();
    }

    #region Damaged_Method
    public void Damaged()
    { 
        if (Player01_turn)
        {
            if (Enemy_Shield > 0)
                Enemy_Shield -= 1;
            else
                Enemy_Hp -= 1;
        }
        else
        {
            if (Player_Shield > 0)
                Player_Shield -= 1;
            else
                Player_Hp -= 1;
        }   
    }
    public void Shield_Damaged()
    {
        if (Player01_turn)
        {
            Enemy_Shield -= 1;
            //Debug.Log($"Player02_Shield: {Enemy_Shield}");
        }
        else if(!Player01_turn)
        {
            Player_Shield -= 1;
           // Debug.Log($"Player01_Shield: {Player_Shield}");
        }
    }
    public void Shield_UP()
    {
        if (Player01_turn)
            Player_Shield += 1;
        else
            Enemy_Shield += 1;
    }
    public void SelfDamaged()
    {
        if (Player01_turn)
        {
            if (Player_Shield > 0)
                Player_Shield -= 1;
            else
                Player_Hp -= 1;
        }
        else
        {
            if (Enemy_Shield > 0)
                Enemy_Shield -= 1;
            else
                Enemy_Hp -= 1;
        }
    }
    public void ReRoll()
    {
        Dice rerollDice = new Dice();
        deck.diceList.Add(rerollDice);
    }
    #endregion

    public void TurnOver()
    {
        if (Player01_turn)
        {
            Player_Button.interactable = true;
            Enemy_Button.interactable = false;
            Player01_Rest_Button.interactable = true;
            Player02_Rest_Button.interactable = false;
            Player01_PowerRoll_Button.interactable=true;
            Player02_PowerRoll_Button.interactable = false;
        }
        else
        {
            Player_Button.interactable = false;
            Enemy_Button.interactable = true;
            Player01_Rest_Button.interactable = false;
            Player02_Rest_Button.interactable = true;
            Player01_PowerRoll_Button.interactable = false;
            Player02_PowerRoll_Button.interactable = true;
        }
        turn++;
    }

    public void GameOver()
    {
        if (Player_Hp <= 0)
        {
            Enemy_Vic_txt.text = "Victory";
            Player_Vic_txt.text = "Defeat";
        }
        else if (Enemy_Hp <= 0)
        {
            Player_Vic_txt.text = "Victory";
            Enemy_Vic_txt.text = "Defeat";
        }
    }

    public void Rest()
    {
        if(Player01_turn)
        {
            Player01_Rest = true;
        }
        else if (!Player01_turn)
        {
            Player02_Rest = true;
        }
        Player01_turn = !Player01_turn;
        TurnOver();
    }
}
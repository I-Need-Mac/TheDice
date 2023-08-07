using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Field
    private int turn = 1;
    #endregion
    
    #region SerializeField
         #region text
    [SerializeField]
    private Text Turn;
    [SerializeField]
    private Text Player01_HP_txt;
    [SerializeField]
    private Text Player02_HP_txt;
    [SerializeField]
    private Text Player01_Shield_txt;
    [SerializeField]
    private Text Player02_Shield_txt;
    [SerializeField]
    private Text Player01_Vic_txt;
    [SerializeField]
    private Text Player02_Vic_txt;
    #endregion text
    [SerializeField]
    private Player Player01;
    [SerializeField]
    private Player Player02;
    #endregion

    #region �̱���
    static public GameManager instance;
    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }
    #endregion

    private void Update()
    {
        Turn.text = $"Turn: {turn}";
        Player01_HP_txt.text = $"HP: {Player01.Hp}";
        Player02_HP_txt.text = $"HP: {Player02.Hp}";
        Player01_Shield_txt.text = $"Shield : {Player01.Shield}";
        Player02_Shield_txt.text = $"Shield : {Player02.Shield}";
        GameOver();
        playAction();
    }

    public void playAction()
    {
        if (Player01.ischoice == true && Player02.ischoice == true)
        {
            Player01.PlayerAction();
            Player02.PlayerAction();
            Player01.DisableAllButtons(true);
            Player02.DisableAllButtons(true);
            Player01.ischoice = false;
            Player02.ischoice = false;
            Player01.isPower = false;
            Player02.isPower = false;
            Player01.isRoll = false;
            Player02.isRoll = false;
            Player01.isRest = false;
            Player02.isRest = false;
            StartCoroutine(TurnOver());
        }
    }
    public void GameOver()
    {
         if(Player01.Hp<=0||Player02.Hp<=0||turn>=15)
         {
             if (Player01.Hp < Player02.Hp)
             {
                 Player02_Vic_txt.text = "Victory";
                 Player01_Vic_txt.text = "Defeat";
             }
             else if (Player02.Hp < Player01.Hp)
             {
                 Player01_Vic_txt.text = "Victory";
                 Player02_Vic_txt.text = "Defeat";
             }
         }
    }
    IEnumerator TurnOver()
    {
        yield return new WaitForSeconds(1.0f);
        turn++;
        Player01.Shield = 0; Player02.Shield =0;
    }
}
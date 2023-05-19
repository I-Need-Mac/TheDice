using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    #region Field
    public int Player_Hp = 15;
    public int Enemy_Hp = 15;
    public int Player_Shield = 0;
    public int Enemy_Shield = 0;
    public int turn = 1;
    bool Players_Turn = true;
    public bool Player_isRest = false;
    public bool Enemy_isRest = false;
    #endregion
    #region SerializeField
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
    private Text Victory_txt;
    [SerializeField]
    private Text Defeat_text;
    [SerializeField]
    private Button Player_Button;
    [SerializeField]
    private Button Enemy_Button;
    [SerializeField]
    private Text Player_Vic_txt;
    [SerializeField]
    private Text Enemy_Vic_txt;
    [SerializeField]
    private Button Player_Rest_Button;
    [SerializeField]
    private Button Enemy_Rest_Button;
    #endregion
    static public GameManager instance;

    private void Awake()
    {
        if(GameManager.instance==null)
        {GameManager.instance = this;}
    }
    private void Start()
    {
        Enemy_Button.interactable = false;
        Turn = GameObject.Find("Turn").GetComponent<Text>();
        Player_HP_txt = GameObject.Find("Player_HP").GetComponent<Text>();
        Enemy_HP_txt = GameObject.Find("Enemy_HP").GetComponent<Text>();
        Player_Shield_txt = GameObject.Find("Player_Shield").GetComponent<Text>();
        Enemy_Shield_txt = GameObject.Find("Enemy_Shield").GetComponent<Text>();
        Player_Vic_txt = GameObject.Find("Player_Vic").GetComponent<Text>();
        Enemy_Vic_txt = GameObject.Find("Enemy_Vic").GetComponent<Text>();
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
    public void Player_Damaged()   { Player_Hp -= 1; }
    public void Enemy_Damaged() { Enemy_Hp-= 1; }
    public void Player_Shield_Damaged() { Player_Shield -= 1; }
    public void Enemy_Shield_Damaged() { Enemy_Shield -= 1;}
    public void Player_Shield_UP() { Player_Shield += 1; }
    public void Enemy_Shield_UP() { Enemy_Shield += 1; }
    #endregion
    public void TurnOver()
    {
        Players_Turn = !Players_Turn;
        turn++;

        if (Players_Turn)
        {
            Player_Button.interactable = true;
            Enemy_Button.interactable = false;

        }
        else if(!Players_Turn)
        {
            Player_Button.interactable = false;
            Enemy_Button.interactable = true;
        }
    }
    public void GameOver()
    {
        if(Player_Hp<=0)
        {
            Enemy_Vic_txt.text = "Victory";
            Player_Vic_txt.text = "Defeat";
        }
        else if(Enemy_Hp<=0)
        {
            Player_Vic_txt.text = "Victory";
            Enemy_Vic_txt.text = "Defeat";
        }
        
    }
    public void Rest()
    {
        TurnOver();  
    }
    
}

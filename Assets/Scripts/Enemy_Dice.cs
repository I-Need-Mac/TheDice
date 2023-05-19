using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dice : MonoBehaviour
{
    public Sprite[] Dice_side;
    private SpriteRenderer spriteRenderer;
    int dicenum;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Roll()
    {

        dicenum = Random.Range(0, 6);
        Sprite SelectedDice = Dice_side[dicenum];
        spriteRenderer.sprite = SelectedDice;
        damaged();
    }
    public void damaged()
    {
        switch (dicenum)
        {
            case 0:
                if (GameManager.instance.Player_Shield > 0)
                { GameManager.instance.Player_Shield_Damaged(); }
                else
                { GameManager.instance.Player_Damaged(); }
                break;
            case 1:
                if (GameManager.instance.Player_Shield > 0)
                { GameManager.instance.Player_Shield_Damaged(); }
                else
                { GameManager.instance.Player_Damaged(); }
                break;
            case 2:
                GameManager.instance.Enemy_Shield_UP();
                 break;
            case 3:
                GameManager.instance.Enemy_Shield_UP();
                break;
            case 4:
                if (GameManager.instance.Enemy_Shield > 0)
                { GameManager.instance.Enemy_Shield_Damaged(); }
                else 
                { GameManager.instance.Enemy_Damaged(); }
                break;
            case 5:
                {
                    Roll();
                    Debug.Log($"{dicenum}");
                    break;
                }
        }
    }
}

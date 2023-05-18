using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //public GameObject[] DicePrefabs;
    //public Transform[] Dicetansforms;
    public Sprite[] Dice_side;
    private SpriteRenderer spriteRenderer;
    private int dicenum;
    
    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Roll()
    {
        //Instantiate(DicePrefabs[0], Dicetansforms[0].position, Quaternion.identity);
        //Instantiate(DicePrefabs[1], Dicetansforms[1].position, Quaternion.identity);
        //Instantiate(DicePrefabs[2], Dicetansforms[2].position, Quaternion.identity);
        //Instantiate(DicePrefabs[3], Dicetansforms[3].position, Quaternion.identity);
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
                if (GameManager.instance.Enemy_Shield > 0)
                { GameManager.instance.Enemy_Shield_Damaged(); }
                else
                { GameManager.instance.Enemy_Damaged();}
                break;
            case 1:
                if (GameManager.instance.Enemy_Shield > 0)
                { GameManager.instance.Enemy_Shield_Damaged(); }
                else
                { GameManager.instance.Enemy_Damaged(); }
                break;
            case 2:
                GameManager.instance.Player_Shield_UP(); break;
            case 3:
                GameManager.instance.Player_Shield_UP(); break;
            case 4:
                if (GameManager.instance.Player_Shield > 0)
                { GameManager.instance.Player_Shield_Damaged(); }
                else
                { GameManager.instance.Player_Damaged(); }
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

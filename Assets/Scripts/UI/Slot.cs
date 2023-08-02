using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    bool hasDice;
    public Text DiceName;
    public Dice dice;

    private void Start()
    {
        DiceName.text = dice.transform.name;
        //GetDice();
    }
    public void GetDice()
    {       
        dice = Instantiate(dice);
        dice.transform.parent = gameObject.transform;
        dice.transform.localPosition = Vector3.zero;
        dice.transform.localScale= Vector3.one;
    }
}

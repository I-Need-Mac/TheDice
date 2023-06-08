using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum DiceType
{
    Attack=1,
    Shield=2,
    Bomb=3,
    Reroll=4
}
public class Dice : MonoBehaviour
{
    DiceType type;

    [SerializeField]
    private int IDNUM;
    [SerializeField]
    private int DiceID;
    [SerializeField]
    private int Rank;
    [SerializeField]
    public int[] Mark;

    public int dicenum;
    public Sprite[] Dice_side;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        CSVReader csvReader = GetComponent<CSVReader>();
        List<List<string>> csvData = csvReader.csvData;
        Mark = new int[6];
        #region CSV Data
        DiceID = int.Parse(csvData[IDNUM][0]);
        Rank = int.Parse(csvData[IDNUM][1]);
        Mark[0] = int.Parse(csvData[IDNUM][2]);
        Mark[1] = int.Parse(csvData[IDNUM][3]);
        Mark[2] = int.Parse(csvData[IDNUM][4]);
        Mark[3] = int.Parse(csvData[IDNUM][5]);
        Mark[4] = int.Parse(csvData[IDNUM][6]);
        Mark[5] = int.Parse(csvData[IDNUM][7]);
        #endregion
    }
    private void Update()
    {

    }
    public void Roll()
    {
        dicenum = Random.Range(0, 6);
        Sprite Selectsprite = Dice_side[dicenum];
        spriteRenderer.sprite = Selectsprite;
        Effect(dicenum);

    }
    void Effect(int dicenum)
    {
        if (Mark[dicenum] == (int)DiceType.Attack)
        {
            GameManager.instance.Damaged();
            Debug.Log("Attack");
        }
        else if (Mark[dicenum] == (int)DiceType.Shield)
        {
            GameManager.instance.Shield_UP();
            Debug.Log("Shield UP");
        }
        else if (Mark[dicenum] == (int)DiceType.Bomb)
        {
            GameManager.instance.SelfDamaged();
            Debug.Log("Bomb");
        }
        else if (Mark[dicenum] == (int)DiceType.Reroll)
        {
            Debug.Log("Reroll");
        }
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}

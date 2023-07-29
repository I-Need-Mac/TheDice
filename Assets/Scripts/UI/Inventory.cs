using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    Slot slot;
    public List<Slot> slotList = new List<Slot>();
    public DeckPanel deckpanel;

    private void Start()
    {
        for(int i=0; i < gameObject.transform.childCount; i++)
        {
            Transform slotposition = gameObject.transform.GetChild(i);
            slot = slotposition.GetComponent<Slot>();
            slotList.Add(slot);
        }
        
    }
    private void Update()
    {
        SlotClick();
    }
    private void SlotClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                slot = hit.transform.GetComponent<Slot>();
                if (slot.dice != null)
                {
                    deckpanel.AddDice(slot.dice);
                    slot.dice.transform.SetParent(deckpanel.deck.transform);
                    slot.dice.GetSpriteRenderer().sprite = null;
                    Vector3 parentScale = transform.parent.lossyScale;
                    slot.dice.transform.localScale = new Vector3(
                        slot.dice.transform.localScale.x / parentScale.x,
                        slot.dice.transform.localScale.y / parentScale.y,
                        slot.dice.transform.localScale.z / parentScale.z
                    );
                }
            }
        }
    }
}


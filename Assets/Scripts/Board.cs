using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform board;
    private void Update()
    {

    }
    public void BoardClear()
    {
            foreach (Transform child in board)
            {
                Destroy(child.gameObject);
            }
    }
}

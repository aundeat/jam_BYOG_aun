using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTake : MonoBehaviour
{
    [SerializeField] private Item itemToadd;
    [SerializeField] private Inventory playerInventory;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            playerInventory.AddItem(itemToadd);
        }
    }
}

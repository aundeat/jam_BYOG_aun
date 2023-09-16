using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Action<Item> onItemAdd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void AddItem(Item item)
    {
        items.Add(item);
        onItemAdd?.Invoke(item);
    }
}

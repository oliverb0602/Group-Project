using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public int itemCount;
    public static int capacity;

    public Inventory()
    {
        itemCount = 0;
        Inventory.capacity = 10;
    }

    public Inventory(int capacity)
    {
        this.itemCount = 0;
        Inventory.capacity = capacity;
    }

    public void AddToInventory()
    {
        if(itemCount < Inventory.capacity)
        {
            this.itemCount++;
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Items> itemList;
    public Inventory(){
        itemList = new List<Items>();
        Debug.Log(itemList.Count);
        AddItem(new Items{ itemType = Items.ItemType.Armor, amount = 1});
        AddItem(new Items{ itemType = Items.ItemType.Coin, amount = 1});
        AddItem(new Items{ itemType = Items.ItemType.Healthpotion, amount = 1});
    } 
    public void AddItem(Items item){
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Items> GetItemList(){
        return itemList;
    }
}

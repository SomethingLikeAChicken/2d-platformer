using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType{
        Armor,
        Healthpotion,
        Coin,
        Sword,

    }
    public ItemType itemType;
    public int amount;
    
    public Sprite GetSprite(){
        switch(itemType){
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
            case ItemType.Healthpotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.Armor:        return ItemAssets.Instance.armorSprite;
        }
    }
}

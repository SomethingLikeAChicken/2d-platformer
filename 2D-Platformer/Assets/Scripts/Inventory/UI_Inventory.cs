using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    private void Awake() {
        
    }
    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshItems();

    }
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshItems();
    }

    public void RefreshItems(){
        foreach(Transform child in itemSlotContainer){
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        foreach(Items items in inventory.GetItemList()){
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y *  itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Item").GetComponent<Image>();
            image.sprite = items.GetSprite();
            x++;
            if(x > 4){
                x = 0;
                y++;
            }
        }
    }
}

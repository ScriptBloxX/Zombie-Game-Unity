using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item_generate item;
    public GameObject Player;
    public void RemoveItem(){
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item_generate newItem){
        item = newItem;
    }
    public void UseItem(){
        Player = GameObject.FindWithTag("Player");
        if(item.itemType == Item_generate.ItemType.Health){
            Player.GetComponent<player_manager>().IncreaseHealth(item.value);
        }else if(item.itemType == Item_generate.ItemType.Stamina){
            Player.GetComponent<player_manager>().IncreaseStamina(item.value);
        }else if(item.itemType == Item_generate.ItemType.Water){
            Player.GetComponent<player_manager>().IncreaseWater(item.value);
        }else if(item.itemType == Item_generate.ItemType.Food){
            Player.GetComponent<player_manager>().IncreaseFood(item.value);
        }
        //Debug.Log(item.name);
        RemoveItem();
    }
}

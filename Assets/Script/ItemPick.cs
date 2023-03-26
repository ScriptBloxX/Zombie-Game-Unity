using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Item_generate Item;
    public bool Pick;
    
    void PickUp(){
        InventoryManager.Instance.Add(Item);
        InventoryManager.Instance.ListItems();
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other){
        if(other.tag.Equals("Player") && Pick==false){
            Pick = true;
            PickUp();
        }
    }       
}

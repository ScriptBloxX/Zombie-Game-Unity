using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item_generate> Items = new List<Item_generate>();

    public Transform ItemContent;
    public GameObject InventoryItem,Player;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item_generate item){
        Items.Add(item);
    }
    public void Remove(Item_generate item){
        Items.Remove(item);
    }

    public void ListItems(){
        // clear item
        foreach(Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        // show item in inventory
        foreach(var item in Items){
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            obj.transform.GetComponent<ItemController>().item = item;
            Debug.Log(obj.transform.GetComponent<ItemController>().item);
        }
    }

    public GameObject InventoryUI;
    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
            if(InventoryUI.activeSelf){
                InventoryUI.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = true;
                Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = true;
            }else{
                ListItems();
                InventoryUI.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
                Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
            }
        }
    }
}

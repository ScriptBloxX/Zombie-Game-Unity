using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class Item_generate : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType{
        Food,
        Water,
        Health,
        Stamina,
        FullFood
    }
}

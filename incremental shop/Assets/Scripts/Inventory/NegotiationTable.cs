using System.Collections.Generic;
using CoreGameplay.Items;
using UnityEngine;

public class NegotiationTable : MonoBehaviour
{
    [SerializeField] protected Inventory playerInventory;
    [SerializeField] protected Transform itemHolder;
    [SerializeField] private ItemView itemViewPrefab;

    private List<GameObject> items = new();
    
    public void AddItem(Item itemConfig)
    {
        ItemView itemView = Instantiate(itemViewPrefab, itemHolder);
        itemView.Setup(itemConfig, playerInventory);
        items.Add(itemView.gameObject);
    }

    public void ClearItems()
    {
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
    }
}

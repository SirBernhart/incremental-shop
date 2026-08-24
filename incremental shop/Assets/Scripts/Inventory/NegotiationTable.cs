using CoreGameplay.Items;
using UnityEngine;

public class NegotiationTable : MonoBehaviour
{
    [SerializeField] protected Inventory playerInventory;
    [SerializeField] protected Transform itemHolder;
    [SerializeField] private ItemView itemViewPrefab;
    
    public void AddItem(Item itemConfig)
    {
        ItemView itemView = Instantiate(itemViewPrefab, itemHolder);
        itemView.Setup(itemConfig, playerInventory);
    }
}

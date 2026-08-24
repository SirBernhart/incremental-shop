using CoreGameplay.Items;
using UnityEngine;

public class NegotiationTable : MonoBehaviour
{
    [SerializeField] protected Inventory playerInventory;
    [SerializeField] protected Transform itemHolder;
    [SerializeField] private ItemView itemViewPrefab;
    
    public void AddItem(Item itemConfig)
    {
        ItemView itemView = InstantiateItemView();
        itemView.Setup(itemConfig, playerInventory);
    }

    protected virtual ItemView InstantiateItemView()
    {
        return Instantiate(itemViewPrefab, itemHolder);
    }
}

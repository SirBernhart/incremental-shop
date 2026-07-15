using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private Transform itemsContainer;
    
    private Dictionary<string, ItemAmount> _itemIdToAmount = new();

    public void AddItem(ItemView itemView)
    {
        if (!_itemIdToAmount.TryGetValue(itemView.ItemConfig.Id, out ItemAmount itemAmount))
        {
            itemAmount = new ItemAmount { Amount = 0, ItemView = itemView };
            _itemIdToAmount.Add(itemView.ItemConfig.Id, itemAmount);
            itemAmount.ItemView.OnItemInteracted = OnItemRemoved;
            
            itemView.transform.SetParent(itemsContainer);
        }
        else
        {
            Destroy(itemView.gameObject);
        }
        
        itemAmount.Amount++;
        _itemIdToAmount[itemAmount.ItemView.ItemConfig.Id] = itemAmount;
    }

    public ItemView TakeItem(ItemView itemView)
    {
        ItemAmount itemAmount = _itemIdToAmount[itemView.ItemConfig.Id];

        itemAmount.Amount--;
        if (itemAmount.Amount <= 0)
        {
            _itemIdToAmount.Remove(itemView.ItemConfig.Id);
        }
        
        return itemView;
    }
    
    protected abstract void OnItemRemoved(ItemView itemView);
}

using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private int itemLimit;
    
    private Dictionary<string, ItemAmount> _itemIdToAmount = new();

    public bool CanFitItem(ItemView itemView)
    {
        if(_itemIdToAmount.ContainsKey(itemView.ItemConfig.Id))
        {
            return true;
        }
        
        return _itemIdToAmount.Count < itemLimit;
    }
    
    public void AddItem(ItemView itemView)
    {
        if (!_itemIdToAmount.TryGetValue(itemView.ItemConfig.Id, out ItemAmount itemAmount))
        {
            if (_itemIdToAmount.Count >= itemLimit)
            {
                return;
            }
            
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
        itemAmount.ItemView.UpdateItemCount(itemAmount.Amount);
        
        _itemIdToAmount[itemAmount.ItemView.ItemConfig.Id] = itemAmount;
    }

    public ItemView TakeItem(ItemView itemView)
    {
        ItemAmount itemAmount = _itemIdToAmount[itemView.ItemConfig.Id];
        ItemView viewToReturn = itemView;
        itemAmount.Amount--;
        if (itemAmount.Amount <= 0)
        {
            _itemIdToAmount.Remove(itemView.ItemConfig.Id);
        }
        else
        {
            itemView.UpdateItemCount(itemAmount.Amount);
            
            viewToReturn = Instantiate(itemView);
            viewToReturn.Setup(itemView.ItemConfig);
        }
        
        return viewToReturn;
    }
    
    protected abstract void OnItemRemoved(ItemView itemView);
}

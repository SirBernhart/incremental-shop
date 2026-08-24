using System;
using System.Collections.Generic;
using System.Linq;
using CoreGameplay.Items;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private int itemLimit;
    [SerializeField] private PlayerInventoryItemView _itemViewPrefab;
    
    private Dictionary<string, ItemAmount> _itemIdToAmount = new();

    public Action OnInventoryItemAmountChanged;

    public bool CanFitItem(ItemView itemView)
    {
        if(_itemIdToAmount.ContainsKey(itemView.ItemConfig.Id))
        {
            return true;
        }
        
        return _itemIdToAmount.Count < itemLimit;
    }
    
    public void AddItem(Item itemConfig)
    {
        if (!_itemIdToAmount.TryGetValue(itemConfig.Id, out ItemAmount itemAmount))
        {
            if (_itemIdToAmount.Count >= itemLimit)
            {
                return;
            }
            
            var inventoryItemView = Instantiate(_itemViewPrefab, itemsContainer);
            inventoryItemView.Setup(itemConfig, this);
            
            itemAmount = new ItemAmount { Amount = 0, ItemView = inventoryItemView };
            _itemIdToAmount.Add(itemConfig.Id, itemAmount);
        }
        
        itemAmount.Amount++;
        itemAmount.ItemView.UpdateItemCount(itemAmount.Amount);
        
        _itemIdToAmount[itemConfig.Id] = itemAmount;
        OnInventoryItemAmountChanged?.Invoke();
    }

    public bool HasItem(ItemView itemView)
    {
        return _itemIdToAmount.ContainsKey(itemView.ItemConfig.Id);
    }

    public void TakeItem(Item itemConfig)
    {
        ItemAmount itemAmount = _itemIdToAmount[itemConfig.Id];
        itemAmount.Amount--;
        if (itemAmount.Amount <= 0)
        {
            _itemIdToAmount.Remove(itemConfig.Id);
            Destroy(itemAmount.ItemView.gameObject);
        }
        else
        {
            itemAmount.ItemView.UpdateItemCount(itemAmount.Amount);
        }
        
        OnInventoryItemAmountChanged?.Invoke();
    }
}

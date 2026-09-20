using System;
using System.Collections.Generic;
using System.Linq;
using CoreGameplay.Items;

public class Inventory
{
    private int _itemLimit = 5;
    private Dictionary<Item, int> _itemConfigToAmount = new();

    public Action<Item, int, int> OnInventoryItemAmountChanged;

    public List<KeyValuePair<Item, int>> GetAllItems()
    {
        return _itemConfigToAmount.ToList();
    }

    public int GetItemCount(Item item)
    {
        _itemConfigToAmount.TryGetValue(item, out int amount);
        return amount;
    }
    
    public bool CanFitItem(Item item)
    {
        if(_itemConfigToAmount.ContainsKey(item))
        {
            return true;
        }
        
        return _itemConfigToAmount.Count < _itemLimit;
    }
    
    public void AddItem(Item itemConfig)
    {
        if (!_itemConfigToAmount.TryGetValue(itemConfig, out int amount))
        {
            if (_itemConfigToAmount.Count >= _itemLimit)
            {
                return;
            }
            
            _itemConfigToAmount.Add(itemConfig, amount);
        }

        int oldAmount = amount;
        amount++;
        
        _itemConfigToAmount[itemConfig] = amount;
        OnInventoryItemAmountChanged?.Invoke(itemConfig, amount, oldAmount);
    }

    public bool HasItem(ItemView itemView)
    {
        return _itemConfigToAmount.ContainsKey(itemView.ItemConfig);
    }

    public void TakeItem(Item itemConfig)
    {
        int itemAmount = _itemConfigToAmount[itemConfig];
        int oldAmount = itemAmount;
        itemAmount--;
        if (itemAmount <= 0)
        {
            _itemConfigToAmount.Remove(itemConfig);
        }
        else
        {
            //TODO: Move to inventory view
            //(itemAmount.ItemView as PlayerInventoryItemView).UpdateItemCount(itemAmount);
        }
        
        OnInventoryItemAmountChanged?.Invoke(itemConfig, itemAmount, oldAmount);
    }
}

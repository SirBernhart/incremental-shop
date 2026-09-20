using System.Collections.Generic;
using CoreGameplay.Items;
using UnityEngine;
using Utils;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private PlayerInventoryItemView _itemViewPrefab;
    [SerializeField] private Transform itemsContainer;

    private void Awake()
    {
        ServicesLocator.Get<Inventory>().OnInventoryItemAmountChanged += HandleInventoryItemAmountChanged;
        InstantiateItemViews();
    }

    private void HandleInventoryItemAmountChanged(Item item, int newAmount, int oldAmount)
    {
        if (oldAmount == 0)
        {
            var inventoryItemView = Instantiate(_itemViewPrefab, itemsContainer);
            inventoryItemView.Setup(item);
            inventoryItemView.UpdateItemCount(newAmount);
        }
    }

    private void InstantiateItemViews()
    {
        List<KeyValuePair<Item, int>> allItems = ServicesLocator.Get<Inventory>().GetAllItems();
        foreach (KeyValuePair<Item, int> itemAndAmount in allItems)
        {
            ItemView itemView = Instantiate(_itemViewPrefab, itemsContainer);
            itemView.Setup(itemAndAmount.Key);
        }
    }
}

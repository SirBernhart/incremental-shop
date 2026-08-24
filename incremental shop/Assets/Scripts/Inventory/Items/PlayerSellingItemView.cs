using UnityEngine;
using Utils;

public class PlayerSellingItemView : ItemView
{
    [SerializeField] private Color _uninteractableColor;
    [SerializeField] private Color _interactableColor;
    [SerializeField] private Color _fulfilledColor;
    
    private bool hasBeenSold;
    
    protected override void Interact()
    {
        PlayerInventory.OnInventoryItemAmountChanged -= HandleOnInventoryItemAmountChanged;
        
        ServicesLocator.Get<CurrencyService>().ChangeCurrencyAmount(ItemConfig.BasePrice);
        UpdateInteractableState();
        icon.color = _fulfilledColor;
        PlayerInventory.TakeItem(ItemConfig);
    }

    protected override void UpdateInteractableState()
    {
        bool inventoryHasItem = PlayerInventory.HasItem(this);

        isInteractable = inventoryHasItem;
        UpdateInteractableColor();
    }

    protected override void HandleOnInventoryItemAmountChanged()
    {
        base.HandleOnInventoryItemAmountChanged();
        
        UpdateInteractableState();
    }

    private void UpdateInteractableColor()
    {
        icon.color = isInteractable ? _interactableColor : _uninteractableColor;
    }
}

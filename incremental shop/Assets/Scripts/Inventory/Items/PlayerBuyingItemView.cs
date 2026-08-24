using UnityEngine;
using Utils;

public class PlayerBuyingItemView : ItemView
{
    [SerializeField] private Color _uninteractableColor;
    [SerializeField] private Color _interactableColor;
    
    protected override void UpdateInteractableState()
    {
        isInteractable = PlayerInventory.CanFitItem(this) 
                         && ServicesLocator.Get<CurrencyService>().HasEnoughCurrency(ItemConfig.BasePrice);
    }

    protected override void Interact()
    {
        PlayerInventory.OnInventoryItemAmountChanged -= HandleOnInventoryItemAmountChanged;
        
        ServicesLocator.Get<CurrencyService>().ChangeCurrencyAmount(-ItemConfig.BasePrice);
        PlayerInventory.AddItem(ItemConfig);
        Destroy(gameObject);
    }

    protected override void HandleOnInventoryItemAmountChanged()
    {
        UpdateInteractableState();
        
        icon.color = isInteractable ? _interactableColor : _uninteractableColor;
    }
}

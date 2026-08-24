using UnityEngine;

public class PlayerBuyingItemView : ItemView
{
    [SerializeField] private Color _uninteractableColor;
    [SerializeField] private Color _interactableColor;
    
    protected override void UpdateInteractableState()
    {
        //TODO: Check for gold
        isInteractable = PlayerInventory.CanFitItem(this);
    }

    protected override void Interact()
    {
        PlayerInventory.OnInventoryItemAmountChanged -= HandleOnInventoryItemAmountChanged;
        
        //TODO: Remove gold
        PlayerInventory.AddItem(ItemConfig);
        Destroy(gameObject);
    }

    protected override void HandleOnInventoryItemAmountChanged()
    {
        UpdateInteractableState();
        
        icon.color = isInteractable ? _interactableColor : _uninteractableColor;
    }
}

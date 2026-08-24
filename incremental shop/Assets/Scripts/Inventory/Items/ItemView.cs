using CoreGameplay.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Image icon;
    [SerializeField] private TMP_Text itemPriceText;
    [SerializeField] private GameObject itemPriceHolder;
    
    protected Inventory PlayerInventory;
    
    public Item ItemConfig {get; private set;}
    
    protected bool isInteractable = true;

    public void Setup(Item config, Inventory playerInventory)
    {
        ItemConfig = config;
        icon.sprite = ItemConfig.Icon;
        PlayerInventory = playerInventory;
        PlayerInventory.OnInventoryItemAmountChanged += HandleOnInventoryItemAmountChanged;
        itemPriceText.text = ItemConfig.BasePrice.ToString();
        UpdateInteractableState();
    }

    protected abstract void UpdateInteractableState();
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isInteractable)
        {
            return;
        }
        
        Interact();
    }

    protected virtual void HandleOnInventoryItemAmountChanged() { }

    protected abstract void Interact();

    private void OnDestroy()
    {
        PlayerInventory.OnInventoryItemAmountChanged -= HandleOnInventoryItemAmountChanged;
    }
}

using CoreGameplay.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Image icon;
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private GameObject itemCountHolder;
    
    protected Inventory PlayerInventory;
    
    public Item ItemConfig {get; private set;}
    
    protected bool isInteractable = true;

    public void Setup(Item config, Inventory playerInventory)
    {
        ItemConfig = config;
        icon.sprite = ItemConfig.Icon;
        PlayerInventory = playerInventory;
        PlayerInventory.OnInventoryItemAmountChanged += HandleOnInventoryItemAmountChanged;
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

    public void UpdateItemCount(int count)
    {
        itemCountHolder.SetActive(count > 1);

        itemCountText.text = count.ToString();
    }

    private void OnDestroy()
    {
        PlayerInventory.OnInventoryItemAmountChanged -= HandleOnInventoryItemAmountChanged;
    }
}

using TMPro;
using UnityEngine;

public class PlayerInventoryItemView : ItemView
{
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private GameObject itemCountHolder;
    
    public void UpdateItemCount(int count)
    {
        itemCountHolder.SetActive(count > 1);

        itemCountText.text = count.ToString();
    }
    
    protected override void UpdateInteractableState()
    {
        // Currently always NOT interactable
    }

    protected override void Interact()
    {
        // TODO: Consider adding a popup that shows item description
    }

    protected override void HandleOnInventoryItemAmountChanged(Item item, int amount, int oldAmount)
    {
        if (amount <= 0)
        {
            Destroy(gameObject);
            return;
        }
        
        UpdateItemCount(amount);
    }
}

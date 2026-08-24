using UnityEngine;

public class PlayerInventoryItemView : ItemView
{
    protected override void UpdateInteractableState()
    {
        // Currently always NOT interactable
    }

    protected override void Interact()
    {
        // TODO: Consider adding a popup that shows item description
    }
}

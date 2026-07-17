using Utils;

public class ClientInventory : Inventory
{
    protected override void OnItemRemoved(ItemView itemView)
    {
        var playerInventory = ServicesLocator.Get<PlayerInventory>();

        if (playerInventory.CanFitItem(itemView))
        {
            return;
        }

        ItemView takenItem = TakeItem(itemView);
        playerInventory.AddItem(takenItem);
    }
}

using Utils;

public class ClientInventory : Inventory
{
    protected override void OnItemRemoved(ItemView itemView)
    {
        TakeItem(itemView);
        ServicesLocator.Get<PlayerInventory>().AddItem(itemView);
    }
}

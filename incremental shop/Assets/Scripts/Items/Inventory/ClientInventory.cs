using Utils;

public class ClientInventory : Inventory
{
    protected override void OnItemRemoved(ItemView itemView)
    {
        ServicesLocator.Get<PlayerInventory>().AddItem(itemView);
    }
}

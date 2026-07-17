using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private ClientInventory negotiationTable;
    
    protected override void OnItemRemoved(ItemView itemView)
    {
        if (!negotiationTable.CanFitItem(itemView))
        {
            return;
        }
        
        ItemView takenItem = TakeItem(itemView);
        negotiationTable.AddItem(takenItem);
    }
}

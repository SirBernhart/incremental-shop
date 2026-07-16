using UnityEngine;

public class PlayerInventory : Inventory
{
    [SerializeField] private ClientInventory negotiationTable;
    
    protected override void OnItemRemoved(ItemView itemView)
    {
        TakeItem(itemView);
        negotiationTable.AddItem(itemView);
    }
}

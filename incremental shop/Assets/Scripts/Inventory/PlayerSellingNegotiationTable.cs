using UnityEngine;

public class PlayerSellingNegotiationTable : NegotiationTable
{
    [SerializeField] private PlayerSellingItemView playerSellingItemViewPrefab;
    
    protected override ItemView InstantiateItemView()
    {
        return Instantiate(playerSellingItemViewPrefab, itemHolder);
    }
}

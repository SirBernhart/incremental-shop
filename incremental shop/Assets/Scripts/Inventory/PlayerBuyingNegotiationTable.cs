using UnityEngine;

public class PlayerBuyingNegotiationTable : NegotiationTable
{
    [SerializeField] private PlayerBuyingItemView playerBuyingItemViewPrefab;
    
    protected override ItemView InstantiateItemView()
    {
        return Instantiate(playerBuyingItemViewPrefab, itemHolder);
    }
}

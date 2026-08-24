using CoreGameplay.Items;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaceholderClient : MonoBehaviour
{
    [SerializeField] private NegotiationTable playerSellingNegotiationTable;
    [SerializeField] private NegotiationTable playerBuyingNegotiationTable;
    [SerializeField] private Item[] possibleItemsToAdd;
    [SerializeField] private int itemsToAddCount;

    private void Awake()
    {
        for (int i = 0; i < itemsToAddCount; i++)
        {
            Item draftedItemToSell = possibleItemsToAdd[Random.Range(0, possibleItemsToAdd.Length)];
            playerBuyingNegotiationTable.AddItem(draftedItemToSell);
            
            Item draftedItemToBuy = possibleItemsToAdd[Random.Range(0, possibleItemsToAdd.Length)];
            playerSellingNegotiationTable.AddItem(draftedItemToBuy);
        }
    }
}

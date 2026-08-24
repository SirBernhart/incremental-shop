using CoreGameplay.Items;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Class that controls Clients and their respective requests
/// </summary>
public class Client : MonoBehaviour
{
    [SerializeField] private NegotiationTable playerSellingNegotiationTable;
    [SerializeField] private NegotiationTable playerBuyingNegotiationTable;

    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private Item[] possibleItemsToAdd;
    [SerializeField] private int itemsToAddCount;

    public void Setup()
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

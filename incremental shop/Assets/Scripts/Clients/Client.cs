using System;
using System.Collections.Generic;
using System.Linq;
using CoreGameplay.Items;
using UnityEngine;

/// <summary>
/// Class that controls Clients and their respective requests
/// </summary>
public class Client : MonoBehaviour
{
    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private Item[] possibleItemsToAdd;
    [SerializeField] private int itemsToAddCount;

    public void Setup(NegotiationTable playerBuyingNegotiationTable, NegotiationTable playerSellingNegotiationTable)
    {
        (List<Item> buyingItems, List<Item> sellingItems) = DraftItems(itemsToAddCount, possibleItemsToAdd);

        playerBuyingNegotiationTable.AddItemRange(buyingItems.ToArray());
        playerSellingNegotiationTable.AddItemRange(sellingItems.ToArray());
    }

    private static (List<Item>, List<Item>) DraftItems(int totalItems, Item[] possibilityPool, bool guaranteeBothBuyAndSell = true)
    {
        var possibilityList = possibilityPool.ToList();

        System.Random random = new System.Random(System.Guid.NewGuid().GetHashCode());

        int separationValue = random.Next(0, Math.Min(totalItems, possibilityList.Count));
        if(guaranteeBothBuyAndSell)
        {
            if(separationValue == 0)
            {
                separationValue++;
            }
            if(separationValue != 1)
            {
                separationValue--;
            }
        }

        int index = 0;

        List<Item> buyingItems = new();
        for(index = 0; index < separationValue; index++)
        {
            (Item draftedItemToSell, int chosenIndex) = draftItem(possibilityList, random);
            buyingItems.Add(draftedItemToSell);

            possibilityList.RemoveAt(chosenIndex);
        }

        List<Item> sellingItems = new();
        for (; index < totalItems; index++)
        {
            (Item draftedItemToBuy, int chosenIndex) = draftItem(possibilityList, random);
            sellingItems.Add(draftedItemToBuy);

            possibilityList.RemoveAt(chosenIndex);
        }

        return (buyingItems, sellingItems);


        static (Item, int) draftItem(List<Item> possibilityPool, System.Random random)
        {
            int index = random.Next(0, possibilityPool.Count);
            return (possibilityPool[index], index);
        }
    }
}

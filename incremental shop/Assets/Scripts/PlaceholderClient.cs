using System;
using CoreGameplay.Items;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaceholderClient : MonoBehaviour
{
    [SerializeField] private ClientInventory inventory;
    [SerializeField] private Item[] possibleItemsToAdd;
    [SerializeField] private int itemsToAddCount;
    [SerializeField] private ItemView itemPrefab;

    private void Awake()
    {
        for (int i = 0; i < itemsToAddCount; i++)
        {
            ItemView itemView = Instantiate(itemPrefab);
            itemView.ItemConfig = possibleItemsToAdd[Random.Range(0, possibleItemsToAdd.Length)];
            inventory.AddItem(itemView);
        }
    }
}

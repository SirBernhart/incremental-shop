using CoreGameplay.Items;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Class that controls Clients and their respective requests
/// </summary>
public class Client : MonoBehaviour
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
            
            itemView.Setup(possibleItemsToAdd[Random.Range(0, possibleItemsToAdd.Length)]);
            inventory.AddItem(itemView);
        }
    }
}

using CoreGameplay.Items;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Class that controls Clients and their respective requests
/// </summary>
public class Client : MonoBehaviour
{
    [SerializeField] private ClientInventory inventory;
    [SerializeField] private ItemView itemPrefab;

    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private Item[] possibleItemsToAdd;
    [SerializeField] private int itemsToAddCount;

    public void Awake()
    {
        SetInventoryVisual(false);
    }

    public void Setup()
    {
        for (int i = 0; i < itemsToAddCount; i++)
        {
            ItemView itemView = Instantiate(itemPrefab);
            
            itemView.Setup(possibleItemsToAdd[Random.Range(0, possibleItemsToAdd.Length)]);
            inventory.AddItem(itemView);
        }

        SetInventoryVisual(true);
    }

    public void SetInventoryVisual(bool active)
    {
        inventory.gameObject.SetActive(active);
    }
}

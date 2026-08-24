using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClientQueueController : MonoBehaviour
{
    [SerializeField] private Client ClientPrefab;
    [SerializeField] private NegotiationTable playerSellingNegotiationTable;
    [SerializeField] private NegotiationTable playerBuyingNegotiationTable;

    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private int numberOfClients = 3; // TODO - migrate to level/day/run config

    private Transform cachedTransform;

    private Queue<Client> clientQueue;

    private void Awake()
    {
        cachedTransform = gameObject.transform;
        clientQueue = new();
    }

    public void Setup()
    {
        for (int i = 0; i < numberOfClients; i++)
        {
            Client client = Instantiate(ClientPrefab, cachedTransform);
            clientQueue.Enqueue(client);
        }

        SetupNextClient();
    }

    public void ClearPreviousClientAndSetupNextClient()
    {
        playerBuyingNegotiationTable.ClearItems();
        playerSellingNegotiationTable.ClearItems();

        Client previousClient = clientQueue.Dequeue();
        Destroy(previousClient.gameObject);
        
        SetupNextClient();
    }
    
    private void SetupNextClient()
    {
        clientQueue.Peek().Setup(playerBuyingNegotiationTable, playerSellingNegotiationTable);
    }
}

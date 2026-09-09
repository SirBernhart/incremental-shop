using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utils;

public class ClientQueueController : MonoBehaviour
{
    [SerializeField] private Client ClientPrefab;
    [SerializeField] private NegotiationTable playerSellingNegotiationTable;
    [SerializeField] private NegotiationTable playerBuyingNegotiationTable;

    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private int numberOfClientsPool = 3; // TODO - migrate to level/day/run config

    private Transform cachedTransform;

    private Queue<Client> clientQueue;

    private void Awake()
    {
        cachedTransform = gameObject.transform;
        clientQueue = new();
    }

    public void Setup()
    {
        for (int i = 0; i < numberOfClientsPool; i++)
        {
            InstantiateNewClientInQueue();
        }
    }

    // Used in Unity Editor: Finish Negotiation button
    public void ClearPreviousClientAndSetupNextClient()
    {
        RemoveCurrentClient();

        if (ShouldInstantiateClient())
        {
            InstantiateNewClientInQueue();
        }

        SetupNextClient();
    }

    private bool ShouldInstantiateClient()
    {
        return clientQueue.Count < numberOfClientsPool
            && ServicesLocator.Get<DayPeriodController>().IsPeriodEnded();
    }

    private void InstantiateNewClientInQueue()
    {
        Client client = Instantiate(ClientPrefab, cachedTransform);
        clientQueue.Enqueue(client);
    }

    private void RemoveCurrentClient()
    {
        playerBuyingNegotiationTable.ClearItems();
        playerSellingNegotiationTable.ClearItems();

        Client previousClient = clientQueue.Dequeue();
        Destroy(previousClient.gameObject);
    }

    private void SetupNextClient()
    {
        if(clientQueue.Count > 0)
        {
            clientQueue.Peek().Setup(playerBuyingNegotiationTable, playerSellingNegotiationTable);
        }
    }
}

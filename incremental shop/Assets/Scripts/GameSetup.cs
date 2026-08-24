using System;
using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private ClientQueueController clientQueue;
    
    private void Awake()
    {
        ServicesLocator.Register<Inventory>(playerInventory);

        ServicesLocator.Register<ClientQueueController>(clientQueue);
        clientQueue.Setup();
    }
}

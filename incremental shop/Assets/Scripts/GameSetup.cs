using System;
using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ClientQueueController clientQueue;
    
    private void Awake()
    {
        ServicesLocator.Register<PlayerInventory>(playerInventory);

        ServicesLocator.Register<ClientQueueController>(clientQueue);
        clientQueue.Setup();
    }
}

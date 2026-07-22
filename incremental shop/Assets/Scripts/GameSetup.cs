using System;
using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ClientQueueController clientQueue;
    [SerializeField] private DayPeriodController dayPeriodController;
    
    private void Awake()
    {
        ServicesLocator.Register(dayPeriodController);

        ServicesLocator.Register(playerInventory);

        ServicesLocator.Register(clientQueue);
        clientQueue.Setup();
    }
}

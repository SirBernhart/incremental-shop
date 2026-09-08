using System;
using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private ClientQueueController clientQueue;
    [SerializeField] private DayPeriodController dayPeriodController;
    
    private void Awake()
    {
        ServicesLocator.Register(dayPeriodController);
        ServicesLocator.Register<Inventory>(playerInventory);

        CurrencyService currencyService = new();
        ServicesLocator.Register<CurrencyService>(currencyService);
        
        ServicesLocator.Register<ClientQueueController>(clientQueue);
        ServicesLocator.Register(clientQueue);
        clientQueue.Setup();
    }
}

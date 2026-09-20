using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private ClientQueueController clientQueue;
    [SerializeField] private DayPeriodController dayPeriodController;
    
    private void Awake()
    {
        ServicesLocator.Register(dayPeriodController);
        if (ServicesLocator.Get<Inventory>() == null)
        {
            ServicesLocator.Register<Inventory>(new Inventory());
        }

        if (ServicesLocator.Get<CurrencyService>() == null)
        {
            CurrencyService currencyService = new();
            ServicesLocator.Register<CurrencyService>(currencyService);
        }
        
        ServicesLocator.Register<ClientQueueController>(clientQueue);
        ServicesLocator.Register(clientQueue);
        clientQueue.Setup();
    }

    public void StartNewDay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

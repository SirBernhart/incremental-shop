using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    
    private void Awake()
    {
        ServicesLocator.Register<Inventory>(playerInventory);
    }
}

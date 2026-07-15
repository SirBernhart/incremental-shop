using UnityEngine;
using Utils;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    
    private void Awake()
    {
        ServicesLocator.Register<PlayerInventory>(playerInventory);
    }
}

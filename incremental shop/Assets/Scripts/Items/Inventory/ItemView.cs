using System;
using CoreGameplay.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    
    public Item ItemConfig {get; private set;}
    
    public Action<ItemView> OnItemInteracted;

    public void Setup(Item config)
    {
        ItemConfig = config;
        
        icon.sprite = ItemConfig.Icon;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemInteracted?.Invoke(this);
    }
}

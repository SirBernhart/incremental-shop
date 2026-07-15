using System;
using CoreGameplay.Items;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemView : MonoBehaviour, IPointerClickHandler
{
    public Item ItemConfig;
    public Action<ItemView> OnItemInteracted;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemInteracted?.Invoke(this);
    }
}

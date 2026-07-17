using System;
using CoreGameplay.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private GameObject itemCountHolder;
    
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

    public void UpdateItemCount(int count)
    {
        itemCountHolder.SetActive(count > 1);

        itemCountText.text = count.ToString();
    }
}

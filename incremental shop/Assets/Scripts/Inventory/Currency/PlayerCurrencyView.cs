using TMPro;
using UnityEngine;
using Utils;

public class PlayerCurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;

    private void Start()
    {
        var currencyService = ServicesLocator.Get<CurrencyService>();
        currencyText.text = currencyService.GetCurrencyAmount().ToString();
        currencyService.OnCurrencyAmountChanged += UpdateAmount;
    }

    private void UpdateAmount(int newAmount)
    {
        currencyText.text = newAmount.ToString();
    }
}

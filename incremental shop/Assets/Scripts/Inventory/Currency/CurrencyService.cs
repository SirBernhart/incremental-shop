using System;

public class CurrencyService
{
    public event Action<int> OnCurrencyAmountChanged;
    
    private int _currencyAmount = 100;

    public void ChangeCurrencyAmount(int amount)
    {
        _currencyAmount += amount;
        OnCurrencyAmountChanged?.Invoke(_currencyAmount);
    }

    public int GetCurrencyAmount()
    {
        return _currencyAmount;
    }

    public bool HasEnoughCurrency(int amount)
    {
        return _currencyAmount >= amount;
    }
}

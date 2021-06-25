using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManagerScript : MonoBehaviour
{
    public static EventManagerScript instance = null;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public class OnAddCurrencyArgs : EventArgs
    {
        public int Amount;
    }

    public event EventHandler<OnAddCurrencyArgs> OnAddCurrency;
    public void AddCurrency(int amount)
    {
        OnAddCurrency?.Invoke(this, new OnAddCurrencyArgs { Amount = amount });
    }

    public class OnUpdateCurrencyUIArgs :EventArgs
    {
        public int ChangeAmount;
        public int Total;
    }

    public event EventHandler<OnUpdateCurrencyUIArgs> OnUpdateCurrencyUI;
    public void UpdateCurrencyUI(int changeamount, int total)
    {
        OnUpdateCurrencyUI?.Invoke(this, new OnUpdateCurrencyUIArgs { ChangeAmount = changeamount, Total = total });
    }

    public class OnAddItemToInventoryArgs : EventArgs
    {
        public SO_Item Item;
        public int Amount;
    }

    public event EventHandler<OnAddItemToInventoryArgs> OnAddItemToInventory;
    public void AddItemToInventory(SO_Item item, int amount)
    {
        OnAddItemToInventory?.Invoke(this, new OnAddItemToInventoryArgs { Item = item, Amount = amount });
    }
}

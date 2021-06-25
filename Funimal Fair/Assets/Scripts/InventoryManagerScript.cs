using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour
{
    private int _currentAmountOfCurrency = 0;
    private List<SO_Item> _defItems = new List<SO_Item>();
    private List<SO_Item> _offItems = new List<SO_Item>();

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.instance.OnAddItemToInventory += AddItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCurrency()
    {
        //future
    }

    void LoadOffItems()
    {
        //future
    }

    void LoadDefItems()
    {
        //future
    }

    void AddItem(object sender, EventManagerScript.OnAddItemToInventoryArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ItemType.Shield:
                if (_defItems.Count<=3)
                {
                    _defItems.Add(e.Item);
                }
                break;
            case ItemType.Weapon:
                _offItems.Add(e.Item);
                if (_defItems.Count <= 3)
                {
                    _defItems.Add(e.Item);
                }
                break;
            case ItemType.Coin:
                _currentAmountOfCurrency += e.Amount;
                EventManagerScript.instance.UpdateCurrencyUI(e.Amount, _currentAmountOfCurrency);
                break;
            default:
                break;
        }

    }

    void BreakItem()
    {
        //ShowItemIsLost;
    }
}

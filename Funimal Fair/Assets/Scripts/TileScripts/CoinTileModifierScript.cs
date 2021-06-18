using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DisplayTileModifierScript))]
[RequireComponent(typeof(DisplayCleanUpScript))]
public class CoinTileModifierScript : TileModifierScript
{
    [SerializeField] private int _amount = 1;
    [SerializeField] private bool _isCoin = false;
    private DisplayTileModifierScript _displayTileModifier = null;
    private DisplayCleanUpScript _displayCleanUpScript = null;
    [SerializeField] private SO_Item _item = null;
    private int _displayID = 0;
    private new void Start()
    {
        if (_isCoin)
        {
            SetCoinItem();
        }
        base.Start();
        _displayTileModifier = GetComponent<DisplayTileModifierScript>();
        _displayCleanUpScript = GetComponent<DisplayCleanUpScript>();
        AddToDisplayTileModifier();
    }

    public override void EnterTile()
    {
        RemoveFromDisplayTileModifier();
        EndEnterTileModifier();
    }

    public override void ExitTile()
    {
        EndExitTileModifier();
    }

    private void AddToDisplayTileModifier()
    {
        if (CheckDisplayTileModifier())
        {
            _displayID = _displayTileModifier.AddItem(_item, _amount);
        }
    }

    private void RemoveFromDisplayTileModifier()
    {
        Debug.Log("AddToCleanUp " + _displayID);
        _displayTileModifier.RemoveItem(_displayID);
        _displayCleanUpScript.AddIndexToCleanUp(_displayID);
        _displayID = -1;
    }

    private bool CheckDisplayTileModifier()
    {
        if (_displayTileModifier)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetCoinItem()
    {
        _item = LevelManagerScript.instance.CoinItem;
    }

}

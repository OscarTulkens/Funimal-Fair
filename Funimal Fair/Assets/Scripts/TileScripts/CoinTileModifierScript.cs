using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DisplayTileModifierScript))]
public class CoinTileModifierScript : TileModifierScript
{
    private DisplayTileModifierScript _displayTileModifier = null;
    [SerializeField] private SO_Item _coin = null;
    private int _displayID = 0;
    private new void Start()
    {
        base.Start();
        //_coin = (SO_Item)Resources.Load("Resources", typeof(SO_Item));
        _displayTileModifier = GetComponent<DisplayTileModifierScript>();
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
            _displayID = _displayTileModifier.AddItem(_coin);
        }
    }

    private void RemoveFromDisplayTileModifier()
    {
        _displayTileModifier.RemoveItem(_displayID);
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DrawConnectionScript))]
public class BaseTileScript : MonoBehaviour
{
    //Shoud be moved to seperate ConnectionModifierScript
    public BaseTileScript NextTile = null;
    //-----

    public List<TileModifierScript> TileModifiers;

    private int _currentEnterModifier = 0;
    private int _currentExitModifier = 0;

    public void StartEnterTileModifiers()
    {
        _currentEnterModifier = 0;
        DoEnterTileModifier();
        LevelManagerScript.instance.ToggleMoving();
    }

    public void ContinueEnterTileModifiers()
    {
        _currentEnterModifier++;
        DoEnterTileModifier();
    }

    private void DoEnterTileModifier()
    {
        if (TileModifiers.Count > _currentEnterModifier)
        {
            TileModifiers[_currentEnterModifier].EnterTile();
        }
        else
        {
            LevelManagerScript.instance.ToggleMoving();
        }
    }

    public void StartExitTileModifiers()
    {
        _currentExitModifier = 0;
        DoExitTileModifiers();
    }

    public void ContinueExitTileModifiers()
    {
        _currentExitModifier++;
        DoExitTileModifiers();
    }

    private void DoExitTileModifiers()
    {
        if (TileModifiers.Count > _currentExitModifier)
        {
            TileModifiers[_currentExitModifier].ExitTile();
        }
    }

}




[System.Serializable]
public struct TileModifierListElement
{
    [SerializeField] public TileModifierScript ModifierComponent;
    [SerializeField] public int _iD;

    public TileModifierListElement(TileModifierScript tilemodifierscript, int id)
    {
        ModifierComponent = tilemodifierscript;
        _iD = id;
    }
}


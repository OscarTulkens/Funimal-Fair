using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileModifierScript : MonoBehaviour
{
    protected BaseTileScript _baseTileScript = null;

    public void Start()
    {
        SetBaseTileScript();
    }

    public void SetBaseTileScript()
    {
        _baseTileScript = transform.GetComponent<BaseTileScript>();
    }

    public abstract void EnterTile();

    public abstract void ExitTile();

    public void EndEnterTileModifier()
    {
        _baseTileScript.ContinueEnterTileModifiers();
    }

    public void EndExitTileModifier()
    {
        _baseTileScript.ContinueExitTileModifiers();
    }
}

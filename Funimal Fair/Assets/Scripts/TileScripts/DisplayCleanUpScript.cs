using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DisplayTileModifierScript))]

public class DisplayCleanUpScript : TileModifierScript
{
    private List<int> _indexesToCleanUp = new List<int>();
    private DisplayTileModifierScript _displayTileModifier;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        _displayTileModifier = GetComponent<DisplayTileModifierScript>();
    }

    public override void EnterTile()
    {
        _indexesToCleanUp.Clear();
        EndEnterTileModifier();
    }

    public override void ExitTile()
    {
        CleanUp();
        EndEnterTileModifier();
    }

    public void AddIndexToCleanUp(int index)
    {
        _indexesToCleanUp.Add(index);
    }

    private void CleanUp()
    {
        _indexesToCleanUp.Sort();

        for (int i = _indexesToCleanUp.Count-1; i >= 0; i--)
        {
            Debug.Log("Destroy " + i);
            _displayTileModifier.DestroyDisplayItem(i);
        }
    }
}

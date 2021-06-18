using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTileModifierScript : TileModifierScript
{
    [Tooltip("Default is y = 0.5f")]
    [SerializeField] private float _displayStartOffset = 0.5f;
    [Tooltip("Default is 0.5f")]
    [SerializeField] private float _displayHeight = 0.55f;
    [SerializeField] private float _moveDisplayDelay = 0.05f;
    private float _delay = 0.2f;
    private float _hoverTime = 1f;

    private List<SO_Item> _so_ItemsOnDisplay = new List<SO_Item>();
    private List<GameObject> _gameobjectItemsOnDisplay = new List<GameObject>();

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    public int AddItem(SO_Item item)
    {
        return AddItem(item, 1);
    }

    public int AddItem(SO_Item item, int amount)
    {
        _so_ItemsOnDisplay.Add(item);
        AddDisplay(item, amount);
        return (_so_ItemsOnDisplay.Count - 1);
    }

    public SO_Item RemoveItem(int index)
    {
        if (index != -1)
        {
            SO_Item tempItem = _so_ItemsOnDisplay[index];
            MinimizeDisplay(index);
            return tempItem;
        }
        else
        {
            return null;
        }
    }

    private void AddDisplay(SO_Item item, int amount)
    {
        //Rework this code to use DISPLAYSCRIPT en DISPLAYPREFAB
        //Add code to adjust amount (overloading additem method?)

        GameObject tempGameObject = Instantiate(LevelManagerScript.instance.DisplayPrefab);
        HoverScript hoverScript = tempGameObject.GetComponent<HoverScript>();
        DisplayScript displayScript = tempGameObject.GetComponent<DisplayScript>();

        displayScript.SetImage(item.Image);
        displayScript.SetAmount(amount);

        hoverScript.HoverOffset = new Vector3(0, 0.20f, 0);
        hoverScript.HoverTime = _hoverTime;
        hoverScript.Delay = _delay * (_gameobjectItemsOnDisplay.Count);

        tempGameObject.transform.localScale = Vector3.one*5;
        tempGameObject.transform.position = transform.position + new Vector3(0, (_displayStartOffset + _gameobjectItemsOnDisplay.Count * _displayHeight));
        tempGameObject.transform.rotation = Quaternion.identity;

        _gameobjectItemsOnDisplay.Add(tempGameObject);
    }

    private void MinimizeDisplay(int index)
    {
        //_gameobjectItemsOnDisplay[index].GetComponent<HoverScript>().StopHover();
        LeanTween.moveLocalY(_gameobjectItemsOnDisplay[index], 0.4f, 0.5f + (index*0.1f)).setEaseInQuad().setDelay(1 + (_delay * index));
        LeanTween.scale(_gameobjectItemsOnDisplay[index], Vector3.zero, 0.35f).setDelay(1.05f + ((0.1f*index) + _delay * index)).setEaseInBack();
    }

    public void DestroyDisplayItem(int index)
    {
        Destroy(_gameobjectItemsOnDisplay[index]);
        _so_ItemsOnDisplay.RemoveAt(index);
        _gameobjectItemsOnDisplay.RemoveAt(index);
    }

    public override void EnterTile()
    {
        MoveDisplayUp();
    }

    public override void ExitTile()
    {
        EndExitTileModifier();
    }

    private void MoveDisplayUp()
    {
        for (int i = _gameobjectItemsOnDisplay.Count-1; i >= 0; i--)
        {
            int tempint = i;
            _gameobjectItemsOnDisplay[i].GetComponent<HoverScript>().StopHover();
            LeanTween.moveLocalY(_gameobjectItemsOnDisplay[i], _displayStartOffset + (i * _displayHeight) + 1f, 0.75f).setEaseOutSine().setDelay((_gameobjectItemsOnDisplay.Count-1-i) * _moveDisplayDelay)/*.setOnComplete((obj) => DisplayStartHoverUp(tempint))*/;
        }
        EndEnterTileModifier();
    }

}

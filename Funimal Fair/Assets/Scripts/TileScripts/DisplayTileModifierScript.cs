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
        _so_ItemsOnDisplay.Add(item);
        AddDisplay(item);
        return _so_ItemsOnDisplay.Count - 1;
    }

    public SO_Item RemoveItem(int index)
    {
        SO_Item tempItem = _so_ItemsOnDisplay[index];
        _so_ItemsOnDisplay.RemoveAt(index);
        return tempItem;
    }

    private void AddDisplay(SO_Item item)
    {
        GameObject tempGameObject = new GameObject(item.name, typeof(SpriteRenderer), typeof(HoverScript));
        HoverScript hoverScript = tempGameObject.GetComponent<HoverScript>();
        SpriteRenderer spriteRender = tempGameObject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = item.Image;
        spriteRender.sortingLayerName = "Characters_Items";

        hoverScript.HoverOffset = new Vector3(0, 0.20f, 0);
        hoverScript.HoverTime = _hoverTime;
        hoverScript.Delay = _delay * (_gameobjectItemsOnDisplay.Count);

        tempGameObject.transform.localScale = Vector3.one*5;
        tempGameObject.transform.position = transform.position + new Vector3(0, (_displayStartOffset + _gameobjectItemsOnDisplay.Count * _displayHeight));
        tempGameObject.transform.rotation = Quaternion.identity;

        _gameobjectItemsOnDisplay.Add(tempGameObject);
    }

    private void RemoveDisplay(int index)
    {

    }

    private void UpdateDisplay()
    {

    }

    public override void EnterTile()
    {
        MoveDisplayUp();
    }

    public override void ExitTile()
    {
        MoveDisplayDown();
    }

    private void MoveDisplayUp()
    {
        for (int i = _gameobjectItemsOnDisplay.Count-1; i >= 0; i--)
        {
            int tempint = i;
            _gameobjectItemsOnDisplay[i].GetComponent<HoverScript>().StopHover();
            LeanTween.moveLocalY(_gameobjectItemsOnDisplay[i], _displayStartOffset + (i * _displayHeight) + 1f, 0.75f).setEaseOutSine().setDelay((_gameobjectItemsOnDisplay.Count-1-i) * _moveDisplayDelay).setOnComplete((obj) => DisplayStartHoverUp(tempint));
        }
        EndEnterTileModifier();
    }

    private void MoveDisplayDown()
    {
        for (int i = 0; i < _gameobjectItemsOnDisplay.Count; i++)
        {
            int tempint = i;
            _gameobjectItemsOnDisplay[i].GetComponent<HoverScript>().StopHover();
            LeanTween.moveLocalY(_gameobjectItemsOnDisplay[i], _displayStartOffset + (i * _displayHeight), 0.75f).setEaseOutSine().setDelay((i) * _moveDisplayDelay).setOnComplete((obj) => DisplayStartHoverDown(tempint));
        }
    }

    private void DisplayStartHoverUp(int index)
    {
        Debug.Log(index);
        _gameobjectItemsOnDisplay[index].GetComponent<HoverScript>().StartHover(transform.position + new Vector3(0, _displayStartOffset + (index * _displayHeight) + 1, 0), (index*_moveDisplayDelay) + (index*_delay));
    }

    private void DisplayStartHoverDown(int index)
    {

        _gameobjectItemsOnDisplay[index].GetComponent<HoverScript>().StartHover();
        EndExitTileModifier();
    }

}

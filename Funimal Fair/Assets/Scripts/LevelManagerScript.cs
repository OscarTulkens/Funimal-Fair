using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [Header("LEVEL RESOURCES")]
    [SerializeField] private GameObject _playerPrefab = null;
    [SerializeField] private SO_Item _coinItem = null;
    [SerializeField] private GameObject _displayPrefab = null;

    private GameObject _startTile = null;
    private GameObject _player = null;
    private bool _movingAllowed = true;

    public GameObject Player { get { return _player; } }
    public SO_Item CoinItem { get { return _coinItem; } }
    public GameObject DisplayPrefab { get { return _displayPrefab; } }

    static public LevelManagerScript instance = null;

    private void Awake()
    {
        SetSingleton();
        FindStartTile();
        InstantiatePlayer();
    }

    private void FindStartTile()
    {
        _startTile = GameObject.FindObjectOfType<StartTileModifierScript>().gameObject;
    }

    private void InstantiatePlayer()
    {
        _player = Instantiate(_playerPrefab, _startTile.transform.position, Quaternion.identity);
        _player.GetComponent<PlayerControllerScript>().SetCurrentTile(_startTile.GetComponent<BaseTileScript>());
    }

    private void SetSingleton()
    {
        instance = this;
    }

    public void ToggleMoving()
    {
        _movingAllowed = !_movingAllowed;
    }
    public void ToggleMoving(bool isMoving)
    {
        _movingAllowed = isMoving;
    }

    public bool CheckMovementBool()
    {
        return _movingAllowed;
    }
}

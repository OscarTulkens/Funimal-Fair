using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab = null;
    private GameObject _startTile = null;
    private GameObject _player = null;
    private bool _movingAllowed = true;

    static public LevelManagerScript instance = null;

    private void Awake()
    {
        SetSingleton();
        FindStartTile();
        InstantiatePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public bool CheckMovementBool()
    {
        return _movingAllowed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private GameObject _startTile;
    private GameObject _player;

    private void Awake()
    {
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
        _startTile = GameObject.FindObjectOfType<StartTileScript>().gameObject;
    }

    private void InstantiatePlayer()
    {
        _player = Instantiate(_playerPrefab, _startTile.transform.position, Quaternion.identity);
        _player.GetComponent<PlayerControllerScript>().SetCurrentTile(_startTile.GetComponent<BaseTileScript>());
    }
}

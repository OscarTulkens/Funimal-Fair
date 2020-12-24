using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private BaseTileScript _currentTile = null;
    private List<int> _ongoingTweens = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovePlayer();
    }

    private void MoveToNextTile()
    {
        CancelAllTweensInList(_ongoingTweens);
        _ongoingTweens.Add(LeanTween.move(gameObject, _currentTile.NextTile.transform.position, _movementSpeed).setEaseInOutSine().id);
    }

    public void SetCurrentTile(BaseTileScript tile)
    {
        _currentTile = tile;
    }

    private void ManageMovePlayer()
    {
        if (Input.GetMouseButtonDown(0) && LevelManagerScript.instance.CheckMovementBool())
        {
            _currentTile.StartExitTileModifiers();
            MoveToNextTile();
            SetCurrentTile(_currentTile.NextTile);
            _currentTile.StartEnterTileModifiers();
        }
    }

    private void CancelAllTweensInList(List<int> _tweenListToCancel)
    {
        foreach (int tween in _tweenListToCancel)
        {
            LeanTween.cancel(tween);
        }
    }
}

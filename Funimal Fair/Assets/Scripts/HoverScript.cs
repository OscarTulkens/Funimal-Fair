using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    private Vector3 _startPosition;
    [SerializeField] private Vector3 _hoverOffset;
    [SerializeField] private float _hoverTime;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.localPosition;
        LeanTween.moveLocal(gameObject, _startPosition + _hoverOffset, _hoverTime).setEaseInOutSine().setLoopPingPong();
    }
}
